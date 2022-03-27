using System;
using System.Runtime.InteropServices;

namespace Snap.Win32
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public static readonly RECT Empty;

        public int Width
        {
            get => Math.Abs(this.Right - this.Left);
        }

        public int Height
        {
            get => this.Bottom - this.Top;
        }

        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public RECT(RECT rcSrc)
        {
            this.Left = rcSrc.Left;
            this.Top = rcSrc.Top;
            this.Right = rcSrc.Right;
            this.Bottom = rcSrc.Bottom;
        }

        public bool IsEmpty
        {
            get =>
                // BUGBUG : On Bidi OS (hebrew arabic) left > right
                this.Left >= this.Right || this.Top >= this.Bottom;
        }

        /// <summary> Return a user friendly representation of this struct </summary>
        public override string ToString()
        {
            if (this == Empty)
            {
                return "RECT {Empty}";
            }
            return "RECT { left : " + this.Left + " / top : " + this.Top + " / right : " + this.Right + " / bottom : " + this.Bottom + " }";
        }

        /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
        public override bool Equals(object? obj)
        {
            return obj is RECT rect && this == rect;
        }

        /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() + this.Top.GetHashCode() + this.Right.GetHashCode() + this.Bottom.GetHashCode();
        }

        /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
        public static bool operator ==(RECT rect1, RECT rect2)
        {
            return rect1.Left == rect2.Left
                && rect1.Top == rect2.Top
                && rect1.Right == rect2.Right
                && rect1.Bottom == rect2.Bottom;
        }

        /// <summary> Determine if 2 RECT are different(deep compare)</summary>
        public static bool operator !=(RECT rect1, RECT rect2)
        {
            return !(rect1 == rect2);
        }
    }
}
