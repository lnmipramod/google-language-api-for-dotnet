﻿/**
 * TranslateRequest.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

namespace Google.API.Translate
{
    internal class TranslateRequest : RequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/language/translate";
        private static readonly string s_LangpairFormat = "{0}%7C{1}";

        public TranslateRequest(string text, string from, string to)
            : base(text)
        {
            From = from;
            To = to;
        }

        public TranslateRequest(string text, string from, string to, TranslateFormat format)
            : this(text, from, to)
        {
            Format = format;
        }

        public string From { get; private set; }

        public string To { get; private set; }

        [Argument("langpair", Optional = false)]
        private string LanguagePair
        {
            get
            {
                string languagePair = string.Format(s_LangpairFormat, From, To);
                return languagePair;
            }
        }

        [Argument("format?")]
        public TranslateFormat Format { get; private set; }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
