using System.Collections.Generic;
using System.Linq;
using SharpKml.Base;

namespace SharpKml.Dom
{
    /// <summary>
    /// Defines a closed line string that should not cross itself.
    /// </summary>
    /// <remarks>
    /// <para>OGC KML 2.2 Section 10.5</para>
    /// <para>If LinearRing is used to define a boundary for a <see cref="Polygon"/>
    /// then <see cref="Extrude"/>, <see cref="Tessellate"/> and
    /// <see cref="LinearRing.AltitudeMode"/> should not be specified.</para>
    /// </remarks>
    [KmlElement("LinearRing")]
    public sealed class LinearRing : Geometry, IBoundsInformation
    {
        private static readonly IEnumerable<Vector> EmptyCoordinates = Enumerable.Empty<Vector>();
        private CoordinateCollection _coords;

        /// <summary>
        /// Gets or sets how the altitude value should be interpreted.
        /// </summary>
        [KmlElement("altitudeMode", 3)]
        public AltitudeMode? AltitudeMode { get; set; }

        /// <summary>Gets or sets a the coordinate tuples.</summary>
        /// <remarks>
        /// Should contain four or more coordinates, where the first and last
        /// coordinates must be the same.
        /// </remarks>
        [KmlElement(null, 4)]
        public CoordinateCollection Coordinates
        {
            get { return _coords; }
            set { this.UpdatePropertyChild(value, ref _coords); }
        }

        /// <summary>
        /// Gets or sets whether to connect a geometry to the ground.
        /// </summary>
        /// <remarks>
        /// The geometry is extruded toward the Earth's center of mass. To
        /// extrude a geometry, <see cref="AltitudeMode"/> shall be either
        /// <see cref="Dom.AltitudeMode.RelativeToGround"/> or
        /// <see cref="Dom.AltitudeMode.Absolute"/>, and the altitude component
        /// should be greater than 0 (that is, in the air).
        /// </remarks>
        [KmlElement("extrude", 1)]
        public bool? Extrude { get; set; }

        /// <summary>
        /// Gets or sets whether to drape a geometry over the terrain.
        /// </summary>
        /// <remarks>
        /// To enable tessellation, the value should be set to true and
        /// <see cref="AltitudeMode"/> shall be <see cref="Dom.AltitudeMode.ClampToGround"/>.
        /// </remarks>
        [KmlElement("tessellate", 2)]
        public bool? Tessellate { get; set; }

        /// <summary>
        /// Gets or sets extended altitude mode information.
        /// [Google Extension]
        /// </summary>
        [KmlElement("altitudeMode", KmlNamespaces.GX22Namespace, 5)]
        public GX.AltitudeMode? GXAltitudeMode { get; set; }

        /// <summary>
        /// Gets the coordinates of the bounds of this instance.
        /// </summary>
        IEnumerable<Vector> IBoundsInformation.Coordinates
        {
            get
            {
                return this.Coordinates ?? EmptyCoordinates;
            }
        }
    }
}
