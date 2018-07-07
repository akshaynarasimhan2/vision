// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Cognitive Services: https://azure.microsoft.com/en-us/services/cognitive-services
// 
// Microsoft Cognitive Services GitHub:
// https://github.com/Microsoft/Cognitive-CustomVision-Windows
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using Common;
using Common.Model;
using ImagesDownloader.DataProvider;
using ImagesDownloader.ImageFilesWritter;
using Microsoft.Cognitive.CustomVision.Training;
using System;

namespace ImagesDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = Options.InitializeOptions<ImagesDownloadOptions>(args);
            if (options == null)
            {
                return;
            }

            var trainingApi = new TrainingApi() { ApiKey = options.Trainingkey };

            if (options.BaseUri != null)
            {
                Console.WriteLine($"The default base uri is {trainingApi.BaseUri}. Changed it to {options.BaseUri}.");
                trainingApi.BaseUri = options.BaseUri;
            }

            string errorMessage;
            if (!options.ValidateWithTrainingApi(trainingApi, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }

            var imageGetter = new ImagesLoaderFromProject(trainingApi, options.ProjectId, options.IterationId, options.AllowedTagNames);
            var images = imageGetter.LoadImages();

            var imageFileWriter = ImageFilesWriterGenerator.GenerateImageFileWriter(options);
            imageFileWriter.WriteImagesToDisk(images);

            var project = new ProjectInfo(trainingApi.GetProject(options.ProjectId));
            project.WriteProjectInfo(options.WorkDir + options.ProjectInfoFileName).Wait();
        }
    }
}
