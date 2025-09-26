using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakLog.Domain.Entities.MediaItems.Interfaces;

public interface IFinishable
{
    bool Finished { get; set; }
    DateTime? FinishedDate { get; set; }
}
