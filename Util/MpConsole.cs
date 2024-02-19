using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MonkeyPaste.Common.Plugin {
    public static class MpConsole {
        #region Private Variables
        #endregion

        #region Properties

        public static MpLogLevel MinLogLevel =>
#if DEBUG
             MpLogLevel.None;
#else
            MpLogLevel.None;
#endif

        public static bool HasInitialized { get; set; } = false;


        static bool IsLogEnabled { get; set; }// =>
                                              //#if DEBUG
                                              //            true;
                                              //#else
                                              //            true;
                                              //#endif

        static string LogFilePath { get; set; }

        #endregion

        #region Public Methods

        public static void Init(string logPath) {
            if (HasInitialized) {
                return;
            }
            HasInitialized = true;
            // NOTE on desktop cefnet MUST be initialized before basically anything (any services)
            // or bizarre crashes occur. So cefnet creates a temp platform info to setup its logging
            // and then initializes console w/ temp info so in main startup init has already happened 

            LogFilePath = logPath;
            IsLogEnabled = logPath != null;

            if (IsLogEnabled) {
                if (IsFileInUse(LogFilePath)) {
                    return;
                }
                try {
                    if (File.Exists(LogFilePath)) {
                        File.Delete(LogFilePath);
                    }
                    if (!Directory.Exists(Path.GetDirectoryName(LogFilePath))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
                    }

                    using (File.Create(LogFilePath)) { }
                    TextWriterTraceListener twtl = new TextWriterTraceListener(LogFilePath);
                    Trace.Listeners.Add(twtl);
                    Trace.AutoFlush = true;
                }
                catch (Exception ex) {
                    WriteTraceLine(@"Error deleting previous log file w/ path: " + LogFilePath + " with exception: " + ex);
                }
            }

        }

        public static void WriteLine(string line, bool pad_pre = false, bool pad_post = false, bool stampless = false, MpLogLevel level = MpLogLevel.Verbose) {
            if (!CanLog(level)) {
                WriteLine($"Log prevented for level: {level}", level: MpLogLevel.Verbose);
                return;
            }
            var sb = new StringBuilder();
            if (!stampless) {
                sb.Append($"{GetLogStamp(level)}");
            }
            sb.Append(line == null ? string.Empty : line);
            WriteLineWrapper(sb.ToString(), false, pad_pre, pad_post);
        }

        public static void WriteTraceLine(object line, object ex = null, MpLogLevel level = MpLogLevel.Error, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int lineNum = 0) {
            if (!CanLog(level)) {
                return;
            }
            line = line == null ? string.Empty : line;

            line = $"{GetLogStamp(level)} {line}";
            WriteLineWrapper("", true);
            WriteLineWrapper(@"-----------------------------------------------------------------------", true);
            WriteLineWrapper("File: " + callerFilePath, true);
            WriteLineWrapper("Member: " + callerName, true);
            WriteLineWrapper("Line: " + lineNum, true);
            WriteLineWrapper("Msg: " + line, true);
            WriteLineWrapper(@"-----------------------------------------------------------------------", true);
            WriteLineWrapper("", true);
            if (ex != null) {
                LogException(ex);
            }
        }

        #endregion

        #region Private Methods

        private static string GetLogStamp(MpLogLevel level) {
            return $"[{DateTime.Now}-{level}] ";
        }

        private static void LogException(object ex, bool isTrace = true, bool recursive = true, int depth = 0) {
            if (ex == null) {
                return;
            }
            if (ex is Exception exObj) {
                string tabs = string.Join(string.Empty, Enumerable.Repeat("\t", depth));
                WriteLineWrapper(tabs + "Exception: ", true);
                WriteLineWrapper(tabs + $"Type: {ex.GetType()}", true);
                WriteLineWrapper(tabs + $"Source: {exObj.Source}", true);
                WriteLineWrapper(tabs + $"StackTrace: {exObj.StackTrace}", true);
                WriteLineWrapper(tabs + $"Message: {exObj.Message}", true);
                WriteLineWrapper(tabs + $"Raw: {ex}");
                if (recursive && exObj.InnerException != null) {
                    LogException(exObj.InnerException, isTrace, recursive, depth + 1);
                }
            } else {
                WriteLineWrapper("Exception: " + ex.ToString(), isTrace);
            }
        }

        private static void WriteLineWrapper(string str, bool isTrace = false, bool pad_pre = false, bool pad_post = false) {
            var sb = new StringBuilder();
            if (pad_pre) {
                sb.AppendLine();
            }
            sb.AppendLine(str);
            if (pad_post) {
                sb.AppendLine();
            }
            if (HasInitialized) {
                Trace.Write(sb.ToString());
            } else {
                // called from an helper app
                Console.WriteLine(sb.ToString().TrimEnd());
            }

        }

        private static bool CanLog(MpLogLevel level) {
            return (int)level >= (int)MinLogLevel;
        }

        static bool IsFileInUse(string path) {
            if (!File.Exists(path)) {
                return false;
            }
            try {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite)) {
                    fs.Close();
                }
            }
            catch {
                return true;
            }
            return false;
        }
        #endregion
    }
}
