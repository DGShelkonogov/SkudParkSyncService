using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkudParkSyncService.Models
{
    public enum DBConnectionStatus
    {
        OPEN,
        MISSING,
        NOT_CONFIGURATED
    }

    public enum ServerType
    {
        LOCAL,
        REMOTE
    }

}
