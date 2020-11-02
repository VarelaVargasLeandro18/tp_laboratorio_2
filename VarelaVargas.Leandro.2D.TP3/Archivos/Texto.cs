﻿using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool ret = false;

            try
            {
                using ( StreamWriter writer = new StreamWriter (archivo, false, Encoding.UTF8) )
                {
                    writer.WriteLine(datos);
                    ret = true;
                }

            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return ret;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool ret = false;

            try
            {
                using (StreamReader reader = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = reader.ReadToEnd();
                    ret = true;
                }

            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return ret;
        }
    }
}