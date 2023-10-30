namespace MoneyManager
{
    /// <summary>
    /// User
    /// </summary>
    internal partial class User
    {
        /// <summary>
        /// Attributes to update.
        /// </summary>
        public enum UpdateAttributes
        {
            /// <summary>
            /// Update Date
            /// </summary>
            Date = 1,
            /// <summary>
            /// Update Amount
            /// </summary>
            Amount = 2,
            /// <summary>
            /// Update AmountMode
            /// </summary>
            AmountMode = 3,
            /// <summary>
            /// Update Category
            /// </summary>
            Category = 4,
            /// <summary>
            /// Update Account Number
            /// </summary>
            Account = 5,
            /// <summary>
            /// Update Notes
            /// </summary>
            Notes = 6,
        }
    }
}
