using System;

namespace IngeniriaProyceto
{
    internal class DllImportAttribute : Attribute
    {
        private string v;
        private string entryPoint;

        public DllImportAttribute(string v, string EntryPoint)
        {
            this.v = v;
            entryPoint = EntryPoint;
        }

        public string EntryPoint { get; set; }
    }
}