﻿

using AllaganLib.GameSheets.Sheets.Rows;

namespace InventorySearchBar.Filters
{
    internal class TypeFilter : Filter
    {
        public override string Name => "Type";
        public override string HelpText => "Allow to filter items by checking if their type contains the search term.\nExamples: '" + Plugin.Settings.NameFilterTag + ":Medicine', '" + Plugin.Settings.NameFilterAbbreviatedTag + ":ingredient', '" + Plugin.Settings.NameFilterTag + ":necklace'.";

        protected override bool Enabled
        {
            get => Plugin.Settings.TypeFilterEnabled;
            set => Plugin.Settings.TypeFilterEnabled = value;
        }

        protected override bool NeedsTag
        {
            get => Plugin.Settings.TypeFilterRequireTag;
            set => Plugin.Settings.TypeFilterRequireTag = value;
        }

        protected override string Tag
        {
            get => Plugin.Settings.TypeFilterTag;
            set => Plugin.Settings.TypeFilterTag = value;
        }

        protected override string AbbreviatedTag
        {
            get => Plugin.Settings.TypeFilterAbbreviatedTag;
            set => Plugin.Settings.TypeFilterAbbreviatedTag = value;
        }

        protected override bool Execute(ItemRow item, string term)
        {
            if (item.Base.ItemUICategory.ValueNullable == null) { return false; }

            return item.Base.ItemUICategory.Value.Name.ExtractText().ToUpper().Contains(term);
        }
    }
}
