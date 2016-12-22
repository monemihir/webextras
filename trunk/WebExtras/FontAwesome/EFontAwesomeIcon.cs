// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using WebExtras.Core;

#pragma warning disable 1591

namespace WebExtras.FontAwesome
{
  /// <summary>
  ///   A collection of all available Font_Awesome library
  ///   bootstrap icons
  /// </summary>
  [Serializable]
  [StringValue(typeof(FontAwesomeIconStringValueDecider))]
  public enum EFontAwesomeIcon
  {
    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    N500Px,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Address_Book,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Address_Book_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Address_Card,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Address_Card_O,
    Adjust,
    Adn,
    Align_Center,
    Align_Justify,
    Align_Left,
    Align_Right,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Amazon,
    Ambulance,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    American_Sign_Language_Interpreting,
    Anchor,
    Android,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Angellist,
    Angle_Double_Down,
    Angle_Double_Left,
    Angle_Double_Right,
    Angle_Double_Up,
    Angle_Down,
    Angle_Left,
    Angle_Right,
    Angle_Up,
    Apple,
    Archive,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Area_Chart,
    Arrow_Circle_Down,
    Arrow_Circle_Left,
    Arrow_Circle_O_Down,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Arrow_Circle_O_Left,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Arrow_Circle_O_Right,
    Arrow_Circle_O_Up,
    Arrow_Circle_Right,
    Arrow_Circle_Up,
    Arrow_Down,
    Arrow_Left,
    Arrow_Right,
    Arrow_Up,
    Arrows,
    Arrows_Alt,
    Arrows_H,
    Arrows_V,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Asl_Interpreting,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Assistive_Listening_Systems,
    Asterisk,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    At,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Audio_Description,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Automobile,
    Backward,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Balance_Scale,
    Ban,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Bandcamp,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Bank,
    Bar_Chart,
    Bar_Chart_O,
    Barcode,
    Bars,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Bath,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Bathtub,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_0,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_1,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_2,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_3,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_4,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_Empty,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_Full,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_Half,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_Quarter,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Battery_Three_Quarters,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Bed,
    Beer,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Behance,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Behance_Square,
    Bell,
    Bell_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Bell_Slash,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Bell_Slash_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Bicycle,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Binoculars,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Birthday_Cake,
    Bitbucket,
    Bitbucket_Square,
    Bitcoin,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Black_Tie,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Blind,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Bluetooth,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Bluetooth_B,
    Bold,
    Bolt,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Bomb,
    Book,
    Bookmark,
    Bookmark_O,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Braille,
    Briefcase,
    Btc,
    Bug,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Building,
    Building_O,
    Bullhorn,
    Bullseye,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Bus,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Buysellads,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Cab,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Calculator,
    Calendar,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Calendar_Check_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Calendar_Minus_O,
    Calendar_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Calendar_Plus_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Calendar_Times_O,
    Camera,
    Camera_Retro,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Car,
    Caret_Down,
    Caret_Left,
    Caret_Right,
    Caret_Square_O_Down,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Caret_Square_O_Left,
    Caret_Square_O_Right,
    Caret_Square_O_Up,
    Caret_Up,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Cart_Arrow_Down,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Cart_Plus,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Amex,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Cc_Diners_Club,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Discover,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Cc_Jcb,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Mastercard,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Paypal,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Stripe,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Cc_Visa,
    Certificate,
    Chain,
    Chain_Broken,
    Check,
    Check_Circle,
    Check_Circle_O,
    Check_Square,
    Check_Square_O,
    Chevron_Circle_Down,
    Chevron_Circle_Left,
    Chevron_Circle_Right,
    Chevron_Circle_Up,
    Chevron_Down,
    Chevron_Left,
    Chevron_Right,
    Chevron_Up,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Child,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Chrome,
    Circle,
    Circle_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Circle_O_Notch,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Circle_Thin,
    Clipboard,
    Clock_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Clone,
    Close,
    Cloud,
    Cloud_Download,
    Cloud_Upload,
    Cny,
    Code,
    Code_Fork,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Codepen,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Codiepie,
    Coffee,
    Cog,
    Cogs,
    Columns,
    Comment,
    Comment_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Commenting,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Commenting_O,
    Comments,
    Comments_O,
    Compass,
    Compress,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Connectdevelop,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Contao,
    Copy,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Copyright,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Creative_Commons,
    Credit_Card,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Credit_Card_Alt,
    Crop,
    Crosshairs,
    Css3,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Cube,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Cubes,
    Cut,
    Cutlery,
    Dashboard,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Dashcube,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Database,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Deaf,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Deafness,
    Dedent,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Delicious,
    Desktop,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Deviantart,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Diamond,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Digg,
    Dollar,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Dot_Circle_O,
    Download,
    Dribbble,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Drivers_License,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Drivers_License_O,
    Dropbox,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Drupal,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Edge,
    Edit,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Eercast,
    Eject,
    Ellipsis_H,
    Ellipsis_V,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Empire,
    Envelope,
    Envelope_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Envelope_Open,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Envelope_Open_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Envelope_Square,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Envira,
    Eraser,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Etsy,
    Eur,
    Euro,
    Exchange,
    Exclamation,
    Exclamation_Circle,
    Exclamation_Triangle,
    Expand,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Expeditedssl,
    External_Link,
    External_Link_Square,
    Eye,
    Eye_Slash,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Eyedropper,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Fa,
    Facebook,
    Facebook_F,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Facebook_Official,
    Facebook_Square,
    Fast_Backward,
    Fast_Forward,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Fax,
    Feed,
    Female,
    Fighter_Jet,
    File,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Archive_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Audio_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Code_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Excel_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Image_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Movie_O,
    File_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Pdf_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Photo_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Picture_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Powerpoint_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Sound_O,
    File_Text,
    File_Text_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Video_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Word_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    File_Zip_O,
    Files_O,
    Film,
    Filter,
    Fire,
    Fire_Extinguisher,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Firefox,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    First_Order,
    Flag,
    Flag_Checkered,
    Flag_O,
    Flash,
    Flask,
    Flickr,
    Floppy_O,
    Folder,
    Folder_O,
    Folder_Open,
    Folder_Open_O,
    Font,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Font_Awesome,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Fonticons,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Fort_Awesome,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Forumbee,
    Forward,
    Foursquare,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Free_Code_Camp,
    Frown_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Futbol_O,
    Gamepad,
    Gavel,
    Gbp,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Ge,
    Gear,
    Gears,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Genderless,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Get_Pocket,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Gg,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Gg_Circle,
    Gift,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Git,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Git_Square,
    Github,
    Github_Alt,
    Github_Square,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Gitlab,
    Gittip,
    Glass,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Glide,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Glide_G,
    Globe,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Google,
    Google_Plus,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Google_Plus_Circle,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Google_Plus_Official,
    Google_Plus_Square,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Google_Wallet,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Graduation_Cap,
    Gratipay,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Grav,
    Group,
    H_Square,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Hacker_News,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Grab_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Lizard_O,
    Hand_O_Down,
    Hand_O_Left,
    Hand_O_Right,
    Hand_O_Up,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Paper_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Peace_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Pointer_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Rock_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Scissors_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Spock_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hand_Stop_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Handshake_O,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Hard_Of_Hearing,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Hashtag,
    Hdd_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Header,
    Headphones,
    Heart,
    Heart_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Heartbeat,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    History,
    Home,
    Hospital_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Hotel,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_1,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_2,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_3,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_End,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_Half,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Hourglass_Start,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Houzz,
    Html5,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    I_Cursor,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Id_Badge,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Id_Card,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Id_Card_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Ils,
    Image,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Imdb,
    Inbox,
    Indent,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Industry,
    Info,
    Info_Circle,
    Inr,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Instagram,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Institution,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Internet_Explorer,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Intersex,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Ioxhost,
    Italic,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Joomla,
    Jpy,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Jsfiddle,
    Key,
    Keyboard_O,
    Krw,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Language,
    Laptop,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Lastfm,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Lastfm_Square,
    Leaf,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Leanpub,
    Legal,
    Lemon_O,
    Level_Down,
    Level_Up,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Life_Bouy,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Life_Buoy,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Life_Ring,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Life_Saver,
    Lightbulb_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Line_Chart,
    Link,
    Linkedin,
    Linkedin_Square,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Linode,
    Linux,
    List,
    List_Alt,
    List_Ol,
    List_Ul,
    Location_Arrow,
    Lock,
    Long_Arrow_Down,
    Long_Arrow_Left,
    Long_Arrow_Right,
    Long_Arrow_Up,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Low_Vision,
    Magic,
    Magnet,
    Mail_Forward,
    Mail_Reply,
    Mail_Reply_All,
    Male,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Map,
    Map_Marker,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Map_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Map_Pin,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Map_Signs,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mars,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mars_Double,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mars_Stroke,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mars_Stroke_H,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mars_Stroke_V,
    Maxcdn,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Meanpath,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Medium,
    Medkit,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Meetup,
    Meh_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Mercury,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Microchip,
    Microphone,
    Microphone_Slash,
    Minus,
    Minus_Circle,
    Minus_Square,
    Minus_Square_O,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Mixcloud,
    Mobile,
    Mobile_Phone,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Modx,
    Money,
    Moon_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Mortar_Board,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Motorcycle,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Mouse_Pointer,
    Music,
    Navicon,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Neuter,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Newspaper_O,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Object_Group,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Object_Ungroup,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Odnoklassniki,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Odnoklassniki_Square,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Opencart,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Openid,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Opera,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Optin_Monster,
    Outdent,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Pagelines,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Paint_Brush,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Paper_Plane,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Paper_Plane_O,
    Paperclip,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Paragraph,
    Paste,
    Pause,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Pause_Circle,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Pause_Circle_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Paw,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Paypal,
    Pencil,
    Pencil_Square,
    Pencil_Square_O,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Percent,
    Phone,
    Phone_Square,
    Photo,
    Picture_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Pie_Chart,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Pied_Piper,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Pied_Piper_Alt,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Pied_Piper_Pp,
    Pinterest,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Pinterest_P,
    Pinterest_Square,
    Plane,
    Play,
    Play_Circle,
    Play_Circle_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Plug,
    Plus,
    Plus_Circle,
    Plus_Square,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Plus_Square_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Podcast,
    Power_Off,
    Print,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Product_Hunt,
    Puzzle_Piece,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Qq,
    Qrcode,
    Question,
    Question_Circle,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Question_Circle_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Quora,
    Quote_Left,
    Quote_Right,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Ra,
    Random,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Ravelry,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Rebel,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Recycle,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Reddit,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Reddit_Alien,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Reddit_Square,
    Refresh,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Registered,
    Remove,
    Renren,
    Reorder,
    Repeat,
    Reply,
    Reply_All,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Resistance,
    Retweet,
    Rmb,
    Road,
    Rocket,
    Rotate_Left,
    Rotate_Right,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Rouble,
    Rss,
    Rss_Square,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Rub,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Ruble,
    Rupee,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    S15,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Safari,
    Save,
    Scissors,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Scribd,
    Search,
    Search_Minus,
    Search_Plus,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Sellsy,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Send,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Send_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Server,
    Share,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Share_Alt,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Share_Alt_Square,
    Share_Square,
    Share_Square_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Shekel,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Sheqel,
    Shield,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Ship,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Shirtsinbulk,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Shopping_Bag,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Shopping_Basket,
    Shopping_Cart,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Shower,
    Sign_In,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Sign_Language,
    Sign_Out,
    Signal,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Signing,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Simplybuilt,
    Sitemap,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Skyatlas,
    Skype,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Slack,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Sliders,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Slideshare,
    Smile_O,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Snapchat,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Snapchat_Ghost,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Snapchat_Square,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Snowflake_O,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Soccer_Ball_O,
    Sort,
    Sort_Alpha_Asc,
    Sort_Alpha_Desc,
    Sort_Amount_Asc,
    Sort_Amount_Desc,
    Sort_Asc,
    Sort_Desc,
    Sort_Down,
    Sort_Numeric_Asc,
    Sort_Numeric_Desc,
    Sort_Up,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Soundcloud,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Space_Shuttle,
    Spinner,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Spoon,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Spotify,
    Square,
    Square_O,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Stack_Exchange,
    Stack_Overflow,
    Star,
    Star_Half,
    Star_Half_Empty,
    Star_Half_Full,
    Star_Half_O,
    Star_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Steam,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Steam_Square,
    Step_Backward,
    Step_Forward,
    Stethoscope,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Sticky_Note,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Sticky_Note_O,
    Stop,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Stop_Circle,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Stop_Circle_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Street_View,
    Strikethrough,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Stumbleupon,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Stumbleupon_Circle,
    Subscript,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Subway,
    Suitcase,
    Sun_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Superpowers,
    Superscript,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Support,
    Table,
    Tablet,
    Tachometer,
    Tag,
    Tags,
    Tasks,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Taxi,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Telegram,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Television,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Tencent_Weibo,
    Terminal,
    Text_Height,
    Text_Width,
    Th,
    Th_Large,
    Th_List,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Themeisle,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_0,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_1,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_2,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_3,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_4,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_Empty,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_Full,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_Half,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_Quarter,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Thermometer_Three_Quarters,
    Thumb_Tack,
    Thumbs_Down,
    Thumbs_O_Down,
    Thumbs_O_Up,
    Thumbs_Up,
    Ticket,
    Times,
    Times_Circle,
    Times_Circle_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Times_Rectangle,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Times_Rectangle_O,
    Tint,
    Toggle_Down,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Toggle_Left,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Toggle_Off,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Toggle_On,
    Toggle_Right,
    Toggle_Up,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Trademark,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Train,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Transgender,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Transgender_Alt,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Trash,
    Trash_O,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Tree,
    Trello,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Tripadvisor,
    Trophy,
    Truck,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Try,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Tty,
    Tumblr,
    Tumblr_Square,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Turkish_Lira,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Tv,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Twitch,
    Twitter,
    Twitter_Square,
    Umbrella,
    Underline,
    Undo,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Universal_Access,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    University,
    Unlink,
    Unlock,
    Unlock_Alt,
    Unsorted,
    Upload,

    /// <summary>
    ///   Since FA v4.5
    /// </summary>
    Usb,
    Usd,
    User,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    User_Circle,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    User_Circle_O,
    User_Md,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    User_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    User_Plus,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    User_Secret,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    User_Times,
    Users,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Vcard,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Vcard_O,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Venus,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Venus_Double,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Venus_Mars,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Viacoin,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Viadeo,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Viadeo_Square,
    Video_Camera,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Vimeo,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Vimeo_Square,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Vine,
    Vk,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Volume_Control_Phone,
    Volume_Down,
    Volume_Off,
    Volume_Up,
    Warning,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Wechat,
    Weibo,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Weixin,

    /// <summary>
    ///   Since FA v4.3
    /// </summary>
    Whatsapp,

    /// <summary>
    ///   Since FA v4.0
    /// </summary>
    Wheelchair,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Wheelchair_Alt,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Wifi,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Wikipedia_W,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Window_Close,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Window_Close_O,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Window_Maximize,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Window_Minimize,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Window_Restore,
    Windows,
    Won,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Wordpress,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Wpbeginner,

    /// <summary>
    ///   Since FA v4.7
    /// </summary>
    Wpexplorer,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Wpforms,
    Wrench,
    Xing,
    Xing_Square,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Y_Combinator,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Y_Combinator_Square,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Yahoo,

    /// <summary>
    ///   Since FA v4.4
    /// </summary>
    Yc,

    /// <summary>
    ///   Since FA v4.1
    /// </summary>
    Yc_Square,

    /// <summary>
    ///   Since FA v4.2
    /// </summary>
    Yelp,
    Yen,

    /// <summary>
    ///   Since FA v4.6
    /// </summary>
    Yoast,
    Youtube,
    Youtube_Play,
    Youtube_Square
  }
}