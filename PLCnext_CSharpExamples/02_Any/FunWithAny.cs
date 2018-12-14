﻿#region Copyright
//  
// Copyright (c) Phoenix Contact GmbH & Co. KG. All rights reserved.  
// Licensed under the MIT. See LICENSE file in the project root for full license information.  
//  
#endregion

using System;
using System.Iec61131Lib;
using Eclr;
using Iec61131.Engineering.Prototypes.Types;
using Iec61131.Engineering.Prototypes.Variables;
using Iec61131.Engineering.Prototypes.Methods;
using Iec61131.Engineering.Prototypes.Common;

namespace ExampleLib
{
    /// <summary>
    /// The example limits a value into a defined range
    /// </summary>
    [Function, DataType("ANY_NUM")]
    public static class Fun_with_ANY
    {

        // All Any parameters must be passed by ref!
        [Execution]
        public unsafe static void __Process(
            [Output] ref Any Fun_with_ANY,
            [Input, DataType("ANY_NUM")] ref Any VALUE,
            [Input, DataType("ANY_NUM")] ref Any MIN,
            [Input, DataType("ANY_NUM")] ref Any MAX)
        {
            // Important due to unsafe programming:
            // Check whether all parameters have the same data type!!!
            if (VALUE.pRuntimeTypeHandle != Fun_with_ANY.pRuntimeTypeHandle || VALUE.pRuntimeTypeHandle != MIN.pRuntimeTypeHandle || VALUE.pRuntimeTypeHandle != MAX.pRuntimeTypeHandle)
            {
                return;
            }

            Eclr.TypeCode code;

            // Get the element type constants associate to the runtime type handle.
            // The values are defined in the standard ECMA-335 "Common Language Infrastructure (CLI)", 
            // Partition II, chapter II.23.1.16 "Element types used in signatures")
            code = (Eclr.TypeCode)Eclr.TypeInfo.GetTypeCode(VALUE.pRuntimeTypeHandle);

            // type dependent action
            if (code == Eclr.TypeCode.Int16)	// i2
            {
                short tempValue = *((short*)VALUE.pValue);
                short tempMin = *((short*)MIN.pValue);
                short tempMax = *((short*)MAX.pValue);
                short* pResult = (short*)Fun_with_ANY.pValue;

                if (tempValue < tempMin)
                {
                    tempValue = tempMin;
                }

                if (tempValue > tempMax)
                {
                    tempValue = tempMax;
                }

                *pResult = tempValue;
            }
            else if (code == Eclr.TypeCode.UInt16)	// u2
            {
                ushort tempValue = *((ushort*)VALUE.pValue);
                ushort tempMin = *((ushort*)MIN.pValue);
                ushort tempMax = *((ushort*)MAX.pValue);
                ushort* pResult = (ushort*)Fun_with_ANY.pValue;

                if (tempValue < tempMin)
                {
                    tempValue = tempMin;
                }

                if (tempValue > tempMax)
                {
                    tempValue = tempMax;
                }

                *pResult = tempValue;
            }
            else if (code == Eclr.TypeCode.Int32)	// i4
            {
                int tempValue = *((int*)VALUE.pValue);
                int tempMin = *((int*)MIN.pValue);
                int tempMax = *((int*)MAX.pValue);
                int* pResult = (int*)Fun_with_ANY.pValue;

                if (tempValue < tempMin)
                {
                    tempValue = tempMin;
                }

                if (tempValue > tempMax)
                {
                    tempValue = tempMax;
                }

                *pResult = tempValue;
            }
            else if (code == Eclr.TypeCode.UInt32)	// u4
            {
                uint tempValue = *((uint*)VALUE.pValue);
                uint tempMin = *((uint*)MIN.pValue);
                uint tempMax = *((uint*)MAX.pValue);
                uint* pResult = (uint*)Fun_with_ANY.pValue;

                if (tempValue < tempMin)
                {
                    tempValue = tempMin;
                }

                if (tempValue > tempMax)
                {
                    tempValue = tempMax;
                }

                *pResult = tempValue;
            }
            else
            {
                // ...
            }
        }
    }
}
