//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GMap.NET.Drawing.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GMap.NET.Drawing.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] arrow {
            get {
                object obj = ResourceManager.GetObject("arrow", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] arrowshadow {
            get {
                object obj = ResourceManager.GetObject("arrowshadow", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] black_small {
            get {
                object obj = ResourceManager.GetObject("black_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] blue {
            get {
                object obj = ResourceManager.GetObject("blue", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] blue_dot {
            get {
                object obj = ResourceManager.GetObject("blue_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] blue_pushpin {
            get {
                object obj = ResourceManager.GetObject("blue_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] blue_small {
            get {
                object obj = ResourceManager.GetObject("blue_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] brown_small {
            get {
                object obj = ResourceManager.GetObject("brown_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на CREATE TABLE IF NOT EXISTS Tiles (id INTEGER NOT NULL PRIMARY KEY, X INTEGER NOT NULL, Y INTEGER NOT NULL, Zoom INTEGER NOT NULL, Type UNSIGNED INTEGER  NOT NULL, CacheTime DATETIME);
        ///CREATE INDEX IF NOT EXISTS IndexOfTiles ON Tiles (X, Y, Zoom, Type);
        ///
        ///CREATE TABLE IF NOT EXISTS TilesData (id INTEGER NOT NULL PRIMARY KEY CONSTRAINT fk_Tiles_id REFERENCES Tiles(id) ON DELETE CASCADE, Tile BLOB NULL);
        ///
        ///-- Foreign Key Preventing insert
        ///CREATE TRIGGER fki_TilesData_id_Tiles_id
        ///BEFORE INSERT ON [TilesDat [остаток строки не уместился]&quot;;.
        /// </summary>
        public static string CreateTileDb {
            get {
                return ResourceManager.GetString("CreateTileDb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] drag_cross_67_16 {
            get {
                object obj = ResourceManager.GetObject("drag_cross_67_16", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] gray_small {
            get {
                object obj = ResourceManager.GetObject("gray_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] green {
            get {
                object obj = ResourceManager.GetObject("green", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] green_big_go {
            get {
                object obj = ResourceManager.GetObject("green_big_go", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] green_dot {
            get {
                object obj = ResourceManager.GetObject("green_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] green_pushpin {
            get {
                object obj = ResourceManager.GetObject("green_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] green_small {
            get {
                object obj = ResourceManager.GetObject("green_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] home {
            get {
                object obj = ResourceManager.GetObject("home", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] landing_place {
            get {
                object obj = ResourceManager.GetObject("landing_place", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] lightblue {
            get {
                object obj = ResourceManager.GetObject("lightblue", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] lightblue_dot {
            get {
                object obj = ResourceManager.GetObject("lightblue_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] lightblue_pushpin {
            get {
                object obj = ResourceManager.GetObject("lightblue_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] msmarker_shadow {
            get {
                object obj = ResourceManager.GetObject("msmarker_shadow", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] orange {
            get {
                object obj = ResourceManager.GetObject("orange", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] orange_dot {
            get {
                object obj = ResourceManager.GetObject("orange_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] orange_small {
            get {
                object obj = ResourceManager.GetObject("orange_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] pink {
            get {
                object obj = ResourceManager.GetObject("pink", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] pink_dot {
            get {
                object obj = ResourceManager.GetObject("pink_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] pink_pushpin {
            get {
                object obj = ResourceManager.GetObject("pink_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] purple {
            get {
                object obj = ResourceManager.GetObject("purple", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] purple_dot {
            get {
                object obj = ResourceManager.GetObject("purple_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] purple_pushpin {
            get {
                object obj = ResourceManager.GetObject("purple_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] purple_small {
            get {
                object obj = ResourceManager.GetObject("purple_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] pushpin_shadow {
            get {
                object obj = ResourceManager.GetObject("pushpin_shadow", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] red {
            get {
                object obj = ResourceManager.GetObject("red", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] red_big_stop {
            get {
                object obj = ResourceManager.GetObject("red_big_stop", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] red_dot {
            get {
                object obj = ResourceManager.GetObject("red_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] red_pushpin {
            get {
                object obj = ResourceManager.GetObject("red_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] red_small {
            get {
                object obj = ResourceManager.GetObject("red_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] selectFrame {
            get {
                object obj = ResourceManager.GetObject("selectFrame", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] shadow_small {
            get {
                object obj = ResourceManager.GetObject("shadow_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] target {
            get {
                object obj = ResourceManager.GetObject("target", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] targetCircle {
            get {
                object obj = ResourceManager.GetObject("targetCircle", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] white_small {
            get {
                object obj = ResourceManager.GetObject("white_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] yellow {
            get {
                object obj = ResourceManager.GetObject("yellow", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] yellow_big_pause {
            get {
                object obj = ResourceManager.GetObject("yellow_big_pause", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] yellow_dot {
            get {
                object obj = ResourceManager.GetObject("yellow_dot", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] yellow_pushpin {
            get {
                object obj = ResourceManager.GetObject("yellow_pushpin", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] yellow_small {
            get {
                object obj = ResourceManager.GetObject("yellow_small", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
