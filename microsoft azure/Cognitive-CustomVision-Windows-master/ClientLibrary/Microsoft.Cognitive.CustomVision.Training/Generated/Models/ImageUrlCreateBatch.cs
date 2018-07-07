// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Cognitive.CustomVision.Training.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ImageUrlCreateBatch
    {
        /// <summary>
        /// Initializes a new instance of the ImageUrlCreateBatch class.
        /// </summary>
        public ImageUrlCreateBatch()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ImageUrlCreateBatch class.
        /// </summary>
        public ImageUrlCreateBatch(IList<ImageUrlCreateEntry> images = default(IList<ImageUrlCreateEntry>), IList<System.Guid> tagIds = default(IList<System.Guid>))
        {
            Images = images;
            TagIds = tagIds;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Images")]
        public IList<ImageUrlCreateEntry> Images { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TagIds")]
        public IList<System.Guid> TagIds { get; set; }

    }
}
