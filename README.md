# LocalMarkdownExplorer

## 概要
LocalMarkdownExplorerは、ローカルのMarkdownファイル用のエクスプローラーです。指定したローカルのディレクトリ内に存在するMarkdown・Textファイルを全文検索でき、HTMLプレビュー表示ができます。.NET Framework4以上で動作します。日本語のみです。

## 利用想定
* ファイルの検索を想定
    * まずファイル名やファイルの内容で検索することを想定しているので、検索ボックスが常時表示されており、また検索ボックスに入力中に全文検索を行います。
* 編集より閲覧を想定
    * Markdownファイルを選択すると、エディター画面ではなくHTMLプレビュー画面が表示される仕様としています。
* ソフトウェア自体の配布を想定
    * 一覧表示させるディレクトリを、絶対パスではなく相対パスでも指定できるようにしているため、このソフトウェア自体をMarkdownファイルと一緒にGit等で共有すれば、そのままビューワーとして利用させることができます。
    * ソフトウェアのデータサイズが小さく・ファイル数も少ないため、配布が容易です。

## 画面
![](http://daybreak3d.nobody.jp/image/tmp/ss04.png)

## 利用
[LocalMarkdownExplorer.zip](https://github.com/negi141/LocalMarkdownExplorer/raw/master/bin/LocalMarkdownExplorer.zip)

## ソースコード
Visual Studio 2010 (C#)

## Copyrights
#### MarkdownDeep
> http://www.toptensoftware.com/markdowndeep/
> Copyright 2010-2011 Topten Software
> 
> Licensed under the Apache License, Version 2.0 (the "License"); you may not use this product except in compliance with the License. You may obtain a copy of the License at
> 
> http://www.apache.org/licenses/LICENSE-2.0
> 
> Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
