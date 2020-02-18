﻿using FileReaders;
using FileWriters;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLogic
{
    public class FileService
    {

        public void ConvertFile(string[] consoleArguments)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var consoleHandler = new ConsoleHandler();
            var inputFileName = string.Empty;
            var outputFileName = string.Empty;
            var format = Format.Json;

            try
            {
                consoleHandler.ParseConsoleArguments(consoleArguments, ref inputFileName, ref outputFileName, ref format);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error($"Arguments are missing. Message: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Incorrect arguments. Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error occured. Message: {ex.Message}");
            }

            var kernel = new StandardKernel(new Bindings(format));

            var writer = kernel.Get<IWriter>();
            var reader = kernel.Get<IReader>();

            try
            {
                var fileProcessor = new FileConverter(writer, reader);
                var studentInfos = fileProcessor.ReadInfoFromFile(inputFileName);
                fileProcessor.WriteRecord(outputFileName, studentInfos);
            }
            catch (FileNotFoundException ex)
            {
                logger.Error($"File does not exist. Filename: {ex.FileName}. Message: {ex.Message}");
            }
            catch (IOException ex)
            {
                logger.Error($"Error occured while working with file. Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error occured. Message: {ex.Message}");
            }
        }
    }
}
