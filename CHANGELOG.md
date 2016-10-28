### Major release: v2.0.0
### Released: n/a

#### The project is now licensed under Apache License v2.0

#### A major namespace shuffle has taken place for the entire library. While all the old functionality is still available, you will have to update your USING statements accordingly. Both WebExtras.Mvc and WebExtras.Nancy libraries now depend on WebExtras library and as such you must add this library to your project

#### Recommended: Creation of HTML components should now be done using the `HtmlComponent` instead of `HtmlElement` class. `HtmlComponent` can then be converted to a `HtmlElement` using the `ToHtmlElement()` extension method in the `WebExtras.Mvc.Html` namespace. `HtmlElement` class is now marked as obsolete and will be removed in the next major release.

- **Enh:** `IBootstrapFormComponent` now gives access to the wrapper `<DIV>` element
- **Enh:** Added ability to retrieve only specific type of alerts from `GetUserAlerts` extension method
- **Enh:** `BootstrapConstants` => `BootstrapSettings`
- **Enh:** Added ability to specify an external string value decider via `WebExtrasSettings.AddStringValueDecider(...)`
- **Enh:** `JsonNetResult` now uses the global JSON serialiser settings set via `WebExtrasSettings.SerialiseSettings`
- **Enh:** `WebExtrasConstants` => `WebExtrasSettings`, `WebExtrasMvcConstants` has been removed
- **Enh:** Errors on model state can now be ignored using the `IgnoreErrors<>` extension method
- **Enh:** Adding `EButton.Back` as a synonym of `EButton.Cancel`
- **Enh:** Adding `IHtmlRenderer.PreRender` to be able to hook into the rendering pipeline just before the compose phase starts
- **Enh:** `GetStringValue` extension method now return the enum value if a `IStringValueDecider` is not associated with the enum rather than throwing an exception
- **Enh:** A form component can now have it's value set via `IFormComponent.SetValue(...)`
- **Enh:** jQuery dataTables bindings now support adding of plugin options via `DatatableSettings.Plugins` property. `Buttons` and `ColVis` plugins are supported out-of-the-box
- **Enh:** Added `Button`, `RequiredFieldLabelFor`, `Image`, `Hyperlink`, `AuthHyperlink`, `Imagelink`, `AuthImagelink` extensions for Nancy
- **Enh:** Added extension method to create SquishIt powered bundles for Nancy
- **Fix:** Fixing a bug in the dropdown creator extension where the selected option was not honoured when the SelectListItem.Selected property was set to true

### Minor release: v1.5.0 
### Released: 03 May 2016

- **Enh:** Further support for jqPlot 
- **Enh:** Added an extension to create Cancel buttons 
- **Enh:** Added ability to create column definitions for jQuery dataTables via utility methods on AOColumn and DatatableRecords classes 
- **Enh:** Added ability to create icon only links in Bootstrap and Gumby 
- **Enh:** Upgrading to FontAwesome 4.1 (I know this is lagging a lot) 
- **Enh:** Adding ability to specify a global pagination scheme for all jQuery dataTables via WebExtrasConstants 
- **Enh:** Adding ability to create Bootstrap3 form group controls 
- **Enh:** Adding a new datetime picker for Bootstrap3 (https://github.com/Eonasdan/bootstrap-datetimepicker) 
- **Enh:** Adding ContainsKey extension for a NameValueCollection 
- **Fix:** Column with no title constraint is no longer enforced if the column is hidden 
- Note: RssReader is now obsolete

#### Older release changelogs will not be included at this time
