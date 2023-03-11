﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Configuration.Static
{
    public enum DatabaseCharacterSet
    {
        UTF_8,
        UTF_16,
        ISO_8859_1,
        WINDOWS_1251,
        ASCII,
        UNICODE
    }

    public enum DatabaseProvider
    {
        MICROSOFT_ACE_OLEDB_12_0,
        MICROSOFT_JET_OLEDB_4_0,
        SQL_CLIENT,
        OLE_DB
    }

    public enum DatabaseSSLMode
    {
        NONE,
        REQUIRED,
        PREFFERED,
        SSL_MODE
    }

    public enum DatabaseServerCertificateValidationMode
    {
        NONE,
        FULL,
        VERIFY_CA,
        VERIFY_FULL,
        VERIFY_HOST_NAME
    }
}
