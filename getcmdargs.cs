// filename = getcmdargs.cs
//
// Written by Ryo CHIBA
// Date: 2017-07-18 (Tue.)
// Compiler: csc.exe (Visual Studio 2015 ; MSBuild 14.0)
// OS: Win10 Enterprise x64

using System;
using System.IO;

public class CommandLineSample
{
  /// <summary>
  /// コマンドライン引数でファイル名を受け取り、そのファイルの中身を表示する。
  /// コマンドライン引数の数がおかしかった場合や、
  /// ファイルが見つからない場合や、ファイルのアクセス権限がない場合、
  /// 終了コード -1 を返して終了する。
  /// 正常終了した場合には終了コード 0 を返す。
  /// </summary>
  public static int Main(string[] args)
  {
    // 引数チェック
    if(args.Length != 1)
    {
      Console.Error.Write("引数の数がおかしいです\n");
      Console.Error.Write ("Usage: getcmdargs [Filename.txt]");
//      Console.Write("引数の数がおかしいです\n");
      return -1;
    }

    StreamReader reader = null;
    try
    {
      // ファイルを開いて中身を表示
      reader = new StreamReader(args[0]);
      string text = reader.ReadToEnd();
      Console.Write(text);
    }
    catch(Exception e)
    {
      // エラー処理
      // 詳しくは「例外処理」で説明します。
      // ファイルが存在しなかったり、アクセス権限がない場合にここが実行される。
      Console.Write(e.Message+"\n");
      return -1;
    }
    finally
    {
      // 後処理
      // これも「例外処理」で説明します。
      if(reader != null)
        reader.Close();
    }

    return 0;
  }
}
