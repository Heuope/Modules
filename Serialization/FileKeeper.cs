using Polenter.Serialization;
using RPGclasses;
using System;
using System.Collections.Generic;

namespace Serialization
{
    class FileKeeper
    {
        public void Serialize(List<Hobo> toSerialize)
        {
            var serializer = new SharpSerializer();

            serializer.Serialize(toSerialize, "test.xml");
        }

        public List<Hobo> DeSerialize()
        {
            var result = new List<Hobo>();

            var serializer = new SharpSerializer();
            try
            {
                result = serializer.Deserialize("test.xml") as List<Hobo>;
            }
            catch (Exception)
            {
                Console.WriteLine(" Some data was not excepted");
            }
            return result;
        }
    }
}
