﻿using CsvHelper;
using Standard.Tool.Platform.Data.Import;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data.Exporting.Exporters
{
    public class CSVExporter<T> : IExporter<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly string _fileNamePrefix;
        private readonly string _directory;

        public CSVExporter(IRepository<T> repository, string fileNamePrefix, string directory)
        {
            _repository = repository;
            _fileNamePrefix = fileNamePrefix;
            _directory = directory;
        }

        public async Task<ExportResult> ExportData<TResult>(Expression<Func<T, TResult>> selector, CancellationToken ct)
        {
            var data = await _repository.SelectAsync(selector, ct);
            var result = await ToCSVResult(data, ct);
            return result;
        }

        private async Task<ExportResult> ToCSVResult<TResult>(IEnumerable<TResult> data, CancellationToken cancellationToken)
        {
            var tempId = Guid.NewGuid().ToString();
            string exportDirectory = ExportManager.CreateExportDirectory(_directory, tempId);

            var distPath = Path.Join(exportDirectory, $"{_fileNamePrefix}-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}.csv");

            await using var writer = new StreamWriter(distPath);
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            await csv.WriteRecordsAsync(data, cancellationToken);

            return new()
            {
                ExportFormat = ExportFormat.SingleCSVFile,
                FilePath = distPath
            };
        }
    }
}
