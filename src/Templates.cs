using System.Collections.Generic;

namespace SharpLauncher
{
    // A class for holding metadata about a game.
    public class MetaDataObj
    {
        // This maps "internal" database column-names to "external" column-names.
        // TODO: use this for translations.
        public static readonly Dictionary<string, string> metadataFields = new Dictionary<string, string>
        {
            { "title", "Title" },
            { "alternateTitles", "Alternate Titles" },
            { "series", "Series" },
            { "developer", "Developer" },
            { "publisher", "Publisher" },
            { "source", "Source" },
            { "releaseDate", "Release Date" },
            { "platform", "Platform" },
            { "version", "Version" },
            { "library", "Library" },
            { "tagsStr", "Tags" },
            { "language", "Language" },
            { "playMode", "Play Mode" },
            { "status", "Status" },
            { "activeDataOnDisk", "Format" },
            { "notes", "Notes" },
            { "originalDescription", "Original Description" }
        };
        public string Title { get; set; } = "";
        public string AlternateTitles { get; set; } = "";
        public string Series { get; set; } = "";
        public string Developer { get; set; } = "";
        public string Publisher { get; set; } = "";
        public string Source { get; set; } = "";
        public string ReleaseDate { get; set; } = "";
        public string Platform { get; set; } = "";
        public string Version { get; set; } = "";
        public string Library { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Language { get; set; } = "";
        public string PlayMode { get; set; } = "";
        public string Status { get; set; } = "";
        public string Format { get; set; } = "";
        public string Notes { get; set; } = "";
        public string OriginalDescription { get; set; } = "";

    }

    // Template for list items
    public class QueryItem
    {
        public string Title { get; set; } = "";
        public string Developer { get; set; } = "";
        public string Publisher { get; set; } = "";
        public string ID { get; set; } = "";
        public string TagsStr { get; set; } = "";
        public string GetPropertyFromName(string field)
        {
            switch (field.ToLower())
            {
                case "title":
                    return Title;
                case "developer":
                    return Developer;
                case "publisher":
                    return Publisher;
                case "id":
                    return ID;
            }
            return "";
        }
    }

    // Template for Add-Apps
    public class AddApp
    {
        public string ID { get; set; } = "";
        public string ParentGameId { get; set; } = "";
        public string Name { get; set; } = "";
        public string ApplicationPath { get; set; } = "";
    }
}
