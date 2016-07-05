#include "stc15f2k60s2.h"
#include "typedef.h"
#include "hwa_uart.h"
#include "math.h"

BOOL taskCycle1msFlag = FALSE;
BOOL taskCycle10msFlag = FALSE;

float x = 0;

data UINT8 u8_sinValue = 0x00;
data UINT16 u16_cosValue = 0x00;

BOOL b_test = FALSE;
UINT8 u8_test = 0x00;
data UINT16 u16_test = 0x00;
xdata UINT32 u32_test = 0x5A;

BOOL b_testFlag = FALSE;

void sys_taskInit(void)
{
    hwa_uartInit();
}
#define FOSC 22118400
#define T1MS (65536-FOSC/12/1000) //12T

void sys_timeInit(void)
{
//	DISABLE_INTERRUPT();
	TMOD &= 0xF0;
	TH0 = (UINT8)(T1MS>>8);
	TL0 = (UINT8)T1MS;
	ET0 = 1;
	TR0 = 1;
//	PT1 = 1;
    EA = 1;
}

void sys_tim0Isr(void) interrupt 1      //1ms cycle task
{
    static UINT8 count = 0;
    if(++count>=10)
    {
        taskCycle10msFlag = TRUE;
        count = 0;
    }
    taskCycle1msFlag = TRUE;
    hwa_uartHandler1ms();
}

void main(void)
{
    UINT8 u8_counter = 0;
    sys_taskInit();
    sys_timeInit();
    b_test = TRUE;
    u8_test++;
    u16_test++;
    u32_test++;
    while(1)
    {
        WDT_CONTR |= 0x35;          //reset watch dog       max time 2.27s
        if(taskCycle1msFlag)
        {
        	taskCycle1msFlag = FALSE;
        }
        if(taskCycle10msFlag)
        {
            taskCycle10msFlag = FALSE;
            hwa_uartHandler10ms();
            x += 0.01;
            if(x > 6.28)
            {
                x = 0;
            }
            u8_sinValue = (UINT16)(128 * sin(x))+128;
            u16_cosValue = (UINT16)(256 * sin(x+3.14/2))+256;
            if(++u8_counter >= 10)
            {
                u8_counter = 0;
                b_testFlag = !b_testFlag;
            }
        }
    }
}
