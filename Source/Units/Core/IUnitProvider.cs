﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitProvider.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Provides units for parsing and formatting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Units
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Provides units for parsing and formatting.
    /// </summary>
    public interface IUnitProvider : IFormatProvider
    {
        /// <summary>
        /// Formats the quantity by the specified format string.
        /// </summary>
        /// <typeparam name="T">
        /// The quantity type. 
        /// </typeparam>
        /// <param name="format">
        /// The format string. 
        /// </param>
        /// <param name="quantity">
        /// The quantity. 
        /// </param>
        /// <returns>
        /// The formatted string. 
        /// </returns>
        string Format<T>(string format, T quantity) where T : IQuantity<T>;

        /// <summary>
        /// Gets the first registered unit (of any quantity type) that matches the specified name.
        /// </summary>
        /// <param name="name">
        /// The name. 
        /// </param>
        /// <returns>
        /// The unit. 
        /// </returns>
        IQuantity GetUnit(string name);

        /// <summary>
        /// Gets the registered units of the specified type.
        /// </summary>
        /// <param name="type">
        /// The type. 
        /// </param>
        /// <returns>
        /// The registered units. 
        /// </returns>
        Dictionary<string, IQuantity> GetUnits(Type type);

        /// <summary>
        /// Registers the unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        void RegisterUnit(IQuantity unit, string name);

        /// <summary>
        /// Sets the display unit.
        /// </summary>
        /// <param name="unit">
        /// The unit. 
        /// </param>
        /// <param name="name">
        /// The name. 
        /// </param>
        void SetDisplayUnit(IQuantity unit, string name);

        /// <summary>
        /// Gets the display unit for the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The type 
        /// </typeparam>
        /// <param name="unit">
        /// The unit (output). 
        /// </param>
        /// <param name="name">
        /// The unit symbol (output). 
        /// </param>
        /// <returns>
        /// True if the display unit was found. 
        /// </returns>
        bool TryGetDisplayUnit<T>(out T unit, out string name);

        /// <summary>
        /// Parses a string.
        /// </summary>
        /// <typeparam name="T">
        /// The type. 
        /// </typeparam>
        /// <param name="input">
        /// The input string. 
        /// </param>
        /// <param name="value">
        /// The value (output). 
        /// </param>
        /// <param name="unit">
        /// The unit (output). 
        /// </param>
        /// <returns>
        /// True if the parsing was successful. 
        /// </returns>
        bool TryParse<T>(string input, out double value, out T unit);
    }
}