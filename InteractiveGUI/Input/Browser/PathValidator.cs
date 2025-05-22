using System;
using System.IO;

namespace InteractiveGUI {
    public class PathValidator : ValidatorAttribute {
        public BrowseType BrowseType { get; set; }

        public PathValidator(BrowseType browseType) {
            BrowseType = browseType;
        }

        public override ValidateResult Validate(object input) {
            if (input.GetType() != typeof(string)) return new ValidateResult(false, "Incorrent type.");

            string path = input as string;
            if (string.IsNullOrEmpty(path)) return new ValidateResult(false, "Path cannot be empty.");

            switch (BrowseType) {
                case BrowseType.Folder:
                    if (Directory.Exists(path)) return true;

                    return new ValidateResult(false, $"The directory '{path}' doesn't exist.");
                case BrowseType.File:
                    if (File.Exists(path)) return true;

                    return new ValidateResult(false, $"The file '{path}' doesn't exist.");
            }

            return false;
        }
    }
}
