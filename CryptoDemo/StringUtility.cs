﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDemo {
  public class StringUtility {
    public static bool IsValid(string input) {
      if (!string.IsNullOrEmpty(input))
        return false;

      return true;
    }
  }
}
