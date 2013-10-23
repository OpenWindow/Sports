using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sports.Domain.Abstract
{
  public interface IImageLibrary
  {
    IQueryable<byte[]> SlideShowImages { get; }
  }
}
