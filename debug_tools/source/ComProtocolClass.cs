using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace debug_tools
{
    /* 标准数据格式：0xAA + LEN + CMD + DATA + VERIFY + 0xCC（DATA可为空）
     *      i.	LEN: CMD + DATA + VERIFY (一个字节)
     *      ii.	VERIFY: LEN XOR CMD XOR DATA（一个字节）
     * 回应格式：    0xBB + CMD + VALUE + 0xCC + 标准数据格式
     */

    class ComStdClass
    {
        private const int MAX_DATA_LEN = 128;
        public byte head;
        public byte len;
        public byte cmd;
        public byte[] dat = new byte[MAX_DATA_LEN];
        public byte check;
        public byte end;

        public bool trig;
        public byte Length { get { return (byte)(len + 3); } }

        private void init(byte _cmd, byte[] _dat, byte _len)
        {
            head = 0xAA;
            len = (byte)(2 + _len);
            cmd = _cmd;
            dat = new byte[MAX_DATA_LEN];
            Array.Copy(_dat, dat, _len);
            check = GetCheck();
            end = 0xCC;
            trig = false;
        }
        public ComStdClass()
        {
            byte[] __dat = new byte[1];
            init((byte)0, __dat, (byte)0);
        }
        public ComStdClass(byte _cmd)
        {
            byte[] __dat = new byte[1];
            init(_cmd, __dat, (byte)0);
        }
        public ComStdClass(byte _cmd, byte[] _dat, byte _len)
        {
            init(_cmd, _dat, _len);
        }
        public ComStdClass(byte _cmd, byte _dat)
        {
            byte[] __dat = new byte[1];
            __dat[0] = _dat;
            init(_cmd, __dat, (byte)1);
        }
        public ComStdClass(byte _cmd, ushort _dat)
        {
            byte[] __dat = new byte[2];
            __dat[0] = (byte)(_dat / 256);
            __dat[1] = (byte)(_dat % 256);
            init(_cmd, __dat, (byte)2);
        }
        public ComStdClass(byte _cmd, uint _dat, ushort _len)
        {
            byte[] __dat = new byte[6];
            __dat[0] = (byte)(_dat >> 24);
            __dat[1] = (byte)(_dat >> 16);
            __dat[2] = (byte)(_dat >> 8);
            __dat[3] = (byte)(_dat >> 0);
            __dat[4] = (byte)(_len >> 8);
            __dat[5] = (byte)(_len >> 0);
            init(_cmd, __dat, (byte)6);
        }
        public ComStdClass(byte _cmd, uint _dat0, ushort _len0, uint _dat1, ushort _len1)
        {
            byte[] __dat = new byte[11];
            __dat[0] = (byte)(_dat0 >> 24);
            __dat[1] = (byte)(_dat0 >> 16);
            __dat[2] = (byte)(_dat0 >> 8);
            __dat[3] = (byte)(_dat0 >> 0);
            __dat[4] = (byte)(_len0 >> 8);
            __dat[5] = (byte)(_len0 >> 0);

            __dat[6] = (byte)(_dat1 >> 24);
            __dat[7] = (byte)(_dat1 >> 16);
            __dat[8] = (byte)(_dat1 >> 8);
            __dat[9] = (byte)(_dat1 >> 0);
            __dat[10] = (byte)(_len1 >> 8);
            __dat[11] = (byte)(_len1 >> 0);
            init(_cmd, __dat, (byte)12);
        }
        public ComStdClass(byte _cmd, uint _dat0, ushort _len0, uint _dat1, ushort _len1, uint _dat2, ushort _len2)
        {
            byte[] __dat = new byte[11];
            __dat[0] = (byte)(_dat0 >> 24);
            __dat[1] = (byte)(_dat0 >> 16);
            __dat[2] = (byte)(_dat0 >> 8);
            __dat[3] = (byte)(_dat0 >> 0);
            __dat[4] = (byte)(_len0 >> 8);
            __dat[5] = (byte)(_len0 >> 0);

            __dat[6] = (byte)(_dat1 >> 24);
            __dat[7] = (byte)(_dat1 >> 16);
            __dat[8] = (byte)(_dat1 >> 8);
            __dat[9] = (byte)(_dat1 >> 0);
            __dat[10] = (byte)(_len1 >> 8);
            __dat[11] = (byte)(_len1 >> 0);

            __dat[12] = (byte)(_dat2 >> 24);
            __dat[13] = (byte)(_dat2 >> 16);
            __dat[14] = (byte)(_dat2 >> 8);
            __dat[15] = (byte)(_dat2 >> 0);
            __dat[16] = (byte)(_len2 >> 8);
            __dat[17] = (byte)(_len2 >> 0);
            
            init(_cmd, __dat, (byte)18);
        }
        public ComStdClass(byte _cmd, uint _dat0, ushort _len0, uint _dat1, ushort _len1, uint _dat2, ushort _len2, uint _dat3, ushort _len3)
        {
            byte[] __dat = new byte[11];
            __dat[0] = (byte)(_dat0 >> 24);
            __dat[1] = (byte)(_dat0 >> 16);
            __dat[2] = (byte)(_dat0 >> 8);
            __dat[3] = (byte)(_dat0 >> 0);
            __dat[4] = (byte)(_len0 >> 8);
            __dat[5] = (byte)(_len0 >> 0);

            __dat[6] = (byte)(_dat1 >> 24);
            __dat[7] = (byte)(_dat1 >> 16);
            __dat[8] = (byte)(_dat1 >> 8);
            __dat[9] = (byte)(_dat1 >> 0);
            __dat[10] = (byte)(_len1 >> 8);
            __dat[11] = (byte)(_len1 >> 0);

            __dat[12] = (byte)(_dat2 >> 24);
            __dat[13] = (byte)(_dat2 >> 16);
            __dat[14] = (byte)(_dat2 >> 8);
            __dat[15] = (byte)(_dat2 >> 0);
            __dat[16] = (byte)(_len2 >> 8);
            __dat[17] = (byte)(_len2 >> 0);

            __dat[18] = (byte)(_dat3 >> 24);
            __dat[19] = (byte)(_dat3 >> 16);
            __dat[20] = (byte)(_dat3 >> 8);
            __dat[21] = (byte)(_dat3 >> 0);
            __dat[22] = (byte)(_len3 >> 8);
            __dat[23] = (byte)(_len3 >> 0);
            init(_cmd, __dat, (byte)24);
        }
        public ComStdClass(byte _cmd, uint _addr, byte[] _dat)
        {
            byte[] __dat = new byte[_dat.Length+4];
            __dat[0] = (byte)(_addr >> 24);
            __dat[1] = (byte)(_addr >> 16);
            __dat[2] = (byte)(_addr >> 8);
            __dat[3] = (byte)(_addr >> 0);
            Array.Copy(_dat, 0, __dat, 4, _dat.Length);
            init(_cmd, __dat, (byte)__dat.Length);
        }
        /*获取接收数据*/
        public bool getArray(byte[] bytes, int length)
        {
            if (length < 4)
            {
                return false;
            }
            try
            {
                head = bytes[0];
                len = bytes[1];
                cmd = bytes[2];
                for (int i = 0; i < length - 2; i++)
                {
                    if (i < MAX_DATA_LEN)
                    {
                        dat[i] = bytes[i + 3];
                    }
                    else
                    {
                        return false;
                    }
                }
                check = bytes[len + 1];
                end = bytes[len + 2];
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*接收校验成功*/
        public bool Checked()
        {
            if (head == 0xAA
                && GetCheck() == check
                && end == 0xCC
                )
            {
                return true;
            }
            return false;
        }
        /*计算校验值*/
        public byte GetCheck()
        {
            byte i, tmpCheck = 0;
            tmpCheck ^= len;
            tmpCheck ^= cmd;
            for (i = 0; i < len - 2; i++)
            {
                tmpCheck ^= dat[i];
            }
            return tmpCheck;
        }
        /*更新校验值*/
        public void updateCheck()
        {
            check = GetCheck();
        }
        public byte[] toArray()
        {
            byte[] tmpbytes = new byte[len + 3];
            tmpbytes[0] = head;
            tmpbytes[1] = len;
            tmpbytes[2] = cmd;
            for (int i = 0; i < len - 2; i++)
            {
                tmpbytes[i + 3] = dat[i];
            }
            tmpbytes[len + 1] = check;
            tmpbytes[len + 2] = end;
            return tmpbytes;
        }
        override public string ToString()
        {
            return System.Text.Encoding.Default.GetString(toArray());
        }
    };
    class ComRxClass
    {
        private const int MAX_DATA_LEN = 128;
        public byte head;
        public byte cmd;
        public byte value;
        public byte end;
        public ComStdClass std;
        public bool expand;
        public bool update;
        public ComRxClass()
        {
            head = 0xBB;
            cmd = 0;
            value = 0;
            end = 0xCC;
            std = new ComStdClass();
            expand = false;
            update = false;
        }
        /*获取接收数据*/
        public bool getArray(byte[] bytes, int length)
        {
            try
            {
                head = bytes[0];
                cmd = bytes[1];
                value = bytes[2];
                end = bytes[3];
                if (length > 4)
                {
                    std.head = bytes[4];
                    std.len = bytes[5];
                    std.cmd = bytes[6];
                    for (int i = 0; i < std.len - 2; i++)
                    {
                        if (i < MAX_DATA_LEN)
                        {
                            std.dat[i] = bytes[i + 7];
                        }
                        else
                        {
                            return false;
                        }
                    }
                    std.check = bytes[std.len + 5];
                    std.end = bytes[std.len + 6];
                    expand = true;
                }
                else
                {
                    expand = false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Checked()
        {
            if (head == 0xBB
                && end == 0xCC
                )
            {
                if (expand == false)
                {
                    return true;
                }
                else if (std.Checked())
                {
                    return true;
                }
            }
            return false;
        }
        public byte[] toArray()
        {
            byte[] tmpArray;
            if (expand)
            {
                tmpArray = new byte[std.len + 7];
            }
            else
            {
                tmpArray = new byte[4];
            }
            tmpArray[0] = head;
            tmpArray[1] = cmd;
            tmpArray[2] = value;
            tmpArray[3] = end;
            if (expand)
            {
                tmpArray[4] = std.head;
                tmpArray[5] = std.len;
                tmpArray[6] = std.cmd;
                for (int i = 0; i < std.len - 2; i++)
                {
                    tmpArray[i + 7] = std.dat[i];
                }
                tmpArray[std.len + 5] = std.check;
                tmpArray[std.len + 6] = std.end;
            }
            return tmpArray;
        }
        override public string ToString()
        {
            return System.Text.Encoding.ASCII.GetString(toArray());
        }
    };
}
