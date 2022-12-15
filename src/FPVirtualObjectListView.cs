using System.Windows.Forms;

using BrightIdeasSoftware;
using static SharpLauncher.Main;

namespace SharpLauncher
{
    /// <summary>
    /// A VirtualObjectListView that creates and initializes an FPVirtualListDataSource as its VirtualListDataSource.
    /// </summary>
    public class FPVirtualObjectListView : VirtualObjectListView
    {
        public FPVirtualObjectListView()
        {
            // Create a new FPVirtualListDataSource for this object's VirtualListDataSource.
            // I couldn't figure out how to do this without messing up Main.Designer.cs or making a new class,
            // so I went with making a new class. Here we are.
            VirtualListDataSource = new FPVirtualListDataSource(this);
        }
    }

    /// <summary>
    /// A "data source" wrapper around queryCache.
    /// </summary>
    /// <remarks>
    /// Currently-implemented features:
    /// <list type="bullet">
    /// <item>Reading the Nth element.</item>
    /// <item>Getting the total number of elements.</item>
    /// <item>Sorting all the elments by a column.</item>
    /// </list>
    /// </remarks>
    public class FPVirtualListDataSource : AbstractVirtualListDataSource
    {
        /// <summary>
        /// Constructs one FPVirtualDataSource object. All it does right now is call the base class constructor.
        /// </summary>
        /// <param name="listView">The VirtualObjectListView that this is a data source for. The base class constructor needs it for some reason.</param>
        public FPVirtualListDataSource(VirtualObjectListView listView) : base(listView)
        {
            // If we end up needing extra init stuff, it goes here.
        }
        
        /// <summary>
        /// Get the an object at an index from queryCache, in a thread-safe manner.
        /// </summary>
        /// <remarks>I declared the return type nullable, we'll see what the compiler thinks of that.</remarks>
        /// <param name="n">The index of the object in queryCache.</param>
        /// <returns>queryCache[n], or null if the index is out of bounds.</returns>
        public override object GetNthObject(int n)
        {
            // Lock queryCache so that nobody else can access it.
            lock (queryCacheLock)
            {
                // Check that the index is in-range.
                if (n >= 0 && n < queryCache.Count)
                {
                    // If it is, return the object nicely.
                    return queryCache[n];
                }
            }
            // The index was out-of-range. The VirtualObjectListView will handle the null.
            return null;
        }

        /// <summary>
        /// Gets the current length of queryCache in a thread-safe manner.
        /// </summary>
        /// <returns>queryCache.Count</returns>
        public override int GetObjectCount()
        {
            // Lock queryCache so that nobody else can access it.
            lock (queryCacheLock)
            {
                // As long as queryCache doesn't shrink, this should be fine.
                // TODO: ensure that the db-refresh calls this correctly.
                return queryCache.Count;
            }
        }

        /// <summary>
        /// Sorts queryCache according to column and order, in a thread-safe manner.
        /// When there are conflicts, uses this.listView.SecondarySortColumn as a tie-breaker, with the same order.
        /// This will be called by ArchiveList whenever the sorting arrows are pressed.
        /// </summary>
        /// <param name="column">The primary column to sort by.</param>
        /// <param name="order">The order in which to sort.</param>
        public override void Sort(OLVColumn column, SortOrder order)
        {
            // If the order is "unordered", don't do anything.
            if (order != SortOrder.None)
            {
                // Construct a new comparer from the column, the order, and the secondary sort column.
                // Note that we use the same order for the secondary sort column.
                var comparer = new ModelObjectComparer(column, order, listView.SecondarySortColumn, order);
                // Lock queryCache so that nobody else can access it.
                lock (queryCacheLock)
                {
                    // Sort queryCache according to the comparer that we just constructed.
                    // This should be pretty efficient - quickSort, if I recall.
                    queryCache.Sort(comparer);
                }
            }
        }
    }
}