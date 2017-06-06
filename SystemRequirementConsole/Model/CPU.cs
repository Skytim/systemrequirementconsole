
namespace SystemRequirementConsole.Model
{
    /// <summary>
    /// CPU Model
    /// </summary>
    public class CPU
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public string Socket { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the width of the address.
        /// </summary>
        /// <value>
        /// The width of the address.
        /// </value>
        public ushort AddressWidth { get; set; }
        /// <summary>
        /// Gets or sets the width of the data.
        /// </summary>
        /// <value>
        /// The width of the data.
        /// </value>
        public ushort DataWidth { get; set; }
        /// <summary>
        /// Gets or sets the architecture.
        /// </summary>
        /// <value>
        /// The architecture.
        /// </value>
        public ushort Architecture { get; set; }

        /// <summary>
        /// Gets or sets the speed m hz.
        /// </summary>
        /// <value>
        /// The speed m hz.
        /// </value>
        public uint SpeedMHz { get; set; }
        /// <summary>
        /// Gets or sets the bus speed m hz.
        /// </summary>
        /// <value>
        /// The bus speed m hz.
        /// </value>
        public uint BusSpeedMHz { get; set; }

        /// <summary>
        /// Gets or sets the l2 cache.
        /// </summary>
        /// <value>
        /// The l2 cache.
        /// </value>
        public ulong L2Cache { get; set; }

        /// <summary>
        /// Gets or sets the l3 cache.
        /// </summary>
        /// <value>
        /// The l3 cache.
        /// </value>
        public ulong L3Cache { get; set; }

        /// <summary>
        /// Gets or sets the cores.
        /// </summary>
        /// <value>
        /// The cores.
        /// </value>
        public uint Cores { get; set; }

        /// <summary>
        /// Gets or sets the threads.
        /// </summary>
        /// <value>
        /// The threads.
        /// </value>
        public uint Threads { get; set; }
    }
}