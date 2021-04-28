using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineFileArchiver
{
    public class ArchiveSettings
    {
        public ArchiveSettings(string _archiveType)
        {
            ArchiveType type ;

            if (Enum.TryParse<ArchiveType>(_archiveType, true, out type))
            {
                ArchiveType = type;
            }
            else
                ArchiveType = ArchiveType.Zip;
            // если не найден указаный тип архива, то используем значение по умолчанию
        }

        public ArchiveType ArchiveType { get; private set; }

                    


            }
        


    }

