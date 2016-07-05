#include "iostm8s105k6.h"
#include "include.h"

#define RUN_MODE_CYCLE				10

UINT8 u8_test = 0;
UINT16 u16_test = 0;
UINT32 u32_test = 0;
UINT8 a_u8_test[10] = {0};

int main(void)
{
    CLK_CKDIVR = 0x00;				/* cpu clock is HSI 16MHz */
	sys_clockInit();
    hwa_uartInit();
    enable_interrupt();
	u8_test++;
	u16_test++;
	u32_test++;
	a_u8_test[0]++;
	while(1)
	{
		if(u8_taskCycleCount >= RUN_MODE_CYCLE)
		{
			u8_taskCycleCount -= RUN_MODE_CYCLE;
			sys_taskCycle10ms();
		}
	}
}