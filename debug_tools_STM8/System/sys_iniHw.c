#include "sys_iniHw.h"


static void sys_taskGpioInit(void)
{
    /*
    DDR  CR1  CR2  ADC_TDR		ģʽ		��������
     0    0    0      x       ��������		  OFF
     0    1    0      x       ��������		   ON
     0    0    1      x     �ж���������	  OFF
     0    1    1      x     �ж���������	   ON
     1    0    0      x       ��©���		  OFF
     1    1    0      x       �������		  OFF
     1    x    1      x         ���		  OFF
     x    x    x      1       ģ������
    */

    /*
    PORTA_PA7:		O	NONE
    PORTA_PA6:		O	NONE
    PORTA_PA5:		O	NONE
    PORTA_PA4:		O	NONE
    PORTA_PA3:		O	NONE
    PORTA_PA2:		O	NONE
    PORTA_PA1:		O	NONE
    PORTA_PA0:		O	NONE
    */
    PA_DDR = 0xFF;
    PA_CR1 = 0xFF;
    PA_CR2 = 0x00;
    PA_ODR = 0x20;

    /*
    PORTB_PB7:		O	NONE
    PORTB_PB6:		O	NONE
    PORTB_PB5:		I	LCD_POW
    PORTB_PB4:		OD	NONE
    PORTB_PB3:		I	KEY_SET
    PORTB_PB2:		I	KEY_UP
    PORTB_PB1:		I	KEY_DN
    PORTB_PB0:		O	LCD_RESET
    */
    PB_DDR = 0xF1;
    PB_CR1 = 0xFF;
    PB_CR2 = 0x00;
    PB_ODR = 0x20;

    /*
    PORTC_PC7:		I	SO
    PORTC_PC6:		O	SI
    PORTC_PC5:		O	SCK
    PORTC_PC4:		O	CS
    PORTC_PC3:		I	IRQ
    PORTC_PC2:		O	RST
    PORTC_PC1:		O	BEEP
    PORTC_PC0:		O	NONE
    */
    PC_DDR = 0x76;
    PC_CR1 = 0x7F;
    PC_CR2 = 0x00;
    PC_ODR = 0xFE;

    /*
    PORTD_PD7:		O	LCD_SDA
    PORTD_PD6:		I	CH_TX
    PORTD_PD5:		O	CH_RX
    PORTD_PD4:		O	LCD_SCL
    PORTD_PD3:		O	LCD_A0
    PORTD_PD2:		O	LCD_CSB
    PORTD_PD1:		I	SWIM
    PORTD_PD0:		O	LCD_LEDA
    */
    PD_DDR = 0xBD;
    PD_CR1 = 0xFF;
    PD_CR2 = 0x00;
    PD_ODR = 0x21;

    /*
    PORTE_PE7:		O	NONE
    PORTE_PE6:		O	NONE
    PORTE_PE5:		I	BEEP
    PORTE_PE4:		O	NONE
    PORTE_PE3:		O	NONE
    PORTE_PE2:		O	NONE
    PORTE_PE1:		O	NONE
    PORTE_PE0:		O	NONE
    */
    PE_DDR = 0xDF;
    PE_CR1 = 0xDF;
    PE_CR2 = 0x00;
    PE_ODR = 0x20;

    /*
    PORTF_PF7:		O	NONE
    PORTF_PF6:		O	NONE
    PORTF_PF5:		O	NONE
    PORTF_PF4:		O	LCD_POW
    PORTF_PF3:		O	NONE
    PORTF_PF2:		O	NONE
    PORTF_PF1:		O	NONE
    PORTF_PF0:		O	NONE
    */
    PF_DDR = 0xEF;
    PF_CR1 = 0xFF;
    PF_CR2 = 0x00;
    PF_ODR = 0x10;
}

void sys_iniHW(void)
{
	sys_taskGpioInit();
	sys_clockInit();
    sys_adcInit();
    sys_pwmInit();
	sys_pwmSet(30);
	sys_clockInit();
    hwa_uartInit();
    //hwa_mifareInit();
}

