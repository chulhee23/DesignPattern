using System;

namespace Adapter
{
    public interface IAdapter {
        void Display(byte[] data);
    }

    public class HdmiToVgaAdapter : IAdapter{
        private LegacyVGA vga = new LegacyVGA();
        public void Display(byte[] data){
            // convert to vga
            vga.Display(data);
        }
    }

    public class LegacyVGA{
        public void Display(byte[] data){
            // ...
        }
    }
    
    public class HdmiAdapter : IAdapter{
        public void Display(byte[] data){
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool vgaMonitor = true;
            IAdapter hdmi;
            if(vgaMonitor){
                hdmi = new HdmiToVgaAdapter();
            } else {
                hdmi = new HdmiAdapter();
            }

            var data = new byte[]{};
            hdmi.Display(data);
        }
    }
}
