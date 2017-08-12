﻿using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Trinity.Network;
using Trinity.Utilities;
using Xunit;

namespace Trinity.FFI.Python.UnitTests
{
    public class PythonFFITest
    {
        [Fact]
        public void LoadPythonFFI_Success()
        {
            Global.Initialize();
            FileUtility.CompletePath(FFIConfig.Instance.ProgramDirectory, create_nonexistent: true);

            // try to invoke trinity-specific python code here
            var fp = Path.Combine(FFIConfig.Instance.ProgramDirectory, "test.py");
            File.WriteAllText(fp, @"
a = trinity.cell('MyCell')
");
            TrinityServer server = new TrinityServer();
            server.Start();

            Global.Uninitialize();
        }
    }
}