#include "iostm8s105k6.h"
#include "include.h"
#include "math.h"

FT32 x = 0;

UINT16 u16_sinValue = 0x00;
UINT16 u16_cosValue = 0x00;
UINT16 u16_sinValue1 = 0x00;
UINT16 u16_cosValue1 = 0x00;

void sys_taskHandler1ms(void)
{
	hwa_uartHandler1ms();
}

void sys_taskCycle10ms(void)
{
	hwa_uartHandler10ms();
	
	x += 0.01;
	if(x > 6.28)
	{
		x = 0;
	}
	u16_sinValue = (UINT16)(32768 * sin(x))+32768;
	u16_cosValue = (UINT16)(32768 * sin(x+3.14/2))+32768;
	u16_sinValue1 = (UINT16)(32768 * sin(x+3.14))+32768;
	u16_cosValue1 = (UINT16)(32768 * sin(x-3.14/2))+32768;
	
}

