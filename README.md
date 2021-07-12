# Introduction

<code>docfx2xml</code> is a tool for building OpenSquiggly-hosted reference documentation
using metadata output from DocFX.

DocFX is an open source static site generated sponsored by Microsoft.

* [DocFX Project Home Page](https://dotnet.github.io/docfx/)
* [DocFX Source Code on GitHub](https://github.com/dotnet/docfx)

# Background

While DocFX is a good tool for what it does, it wasn't designed to produce output that is
appropriately formatted for hosting inside of OpenSquiggly. As with other static site generators,
it generates full server-side rendered pages designed to be served from a CDN or a static web
page hosting site such as GitHub Pages or Netlify.

That doesn't work for OpenSquiggly because these pages contain too much information. They are
fully-formed presentation-oriented web pages containing styles, a table of contents, embedded
JavaScript code, a lightweight search engine, etc.

What we need for OpenSquiggly is a directory structure containing content-only HTML, Markdown,
or XML files. OpenSquiggly then handles dynamically generating the table of contents and indexing
of pages for searching, requiring only the content that is to be displayed in the content pane
to be contained in the actual files.

XML is a particularly good format for displaying reference documentation inside of OpenSquiggly.
Because OpenSquiggly supports XSLT transforms, reference documentation can be written in a
semantic-oriented structure, and the associated XSL file can transform it into the final
presentation format dynamically.

The DocFX "metadata" process will generate a set of YAML files. While YAML files are good in the
sense that they contain semantic structure, since they aren't XML files they can't be transformed
using XSLT.

<code>docfx2xml</code> is a tool that transforms the YAML metadata produced by DocFX into a set
of XML files that can be hosted and displayed inside of OpenSquiggly.
