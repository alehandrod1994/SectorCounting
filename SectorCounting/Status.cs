namespace SectorCounting
{
    /// <summary>
    /// Статус выполнения процесса.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Не удалось сохранить файл.
        /// </summary>
        NotSave,

        /// <summary>
        /// Готов к выполнению процесса.
        /// </summary>
        Start,

        /// <summary>
        /// Успешное завершение процесса.
        /// </summary>
        Success
    }
}
