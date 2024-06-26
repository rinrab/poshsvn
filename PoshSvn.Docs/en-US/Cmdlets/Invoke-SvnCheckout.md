---
external help file: PoshSvn.dll-Help.xml
Module Name: PoshSvn
online version: https://www.poshsvn.com/docs/Invoke-SvnCheckout/
schema: 2.0.0
---

# Invoke-SvnCheckout

## SYNOPSIS
Check out a working copy from a repository.

## SYNTAX

```
Invoke-SvnCheckout [-Url] <Uri> [[-Path] <String>] [-Revision <SvnRevision>] [-IgnoreExternals] [-Force]
 [<CommonParameters>]
```

## DESCRIPTION
Check out a working copy from a repository.

## EXAMPLES

### Example 1: Check out a working copy

Check out the serf repository into 'serf-trunk' directory:

```powershell
svn-checkout https://svn.apache.org/repos/asf/serf/trunk serf-trunk
```

## PARAMETERS

### -Force
Force operation to run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: f

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreExternals
Tells Subversion to ignore externals definitions and the external working copies managed by them.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: ignore-externals

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specifies a Path of a working copy. If PATH is omitted, the basename of the URL will be used as the destination.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Revision
Specifies a revision on with which to operate. You can provide revision numbers, keywords, or dates (in curly braces) as arguments to the revision option. If you wish to offer a range of revisions, you can provide two revisions separated by a colon.

```yaml
Type: SvnRevision
Parameter Sets: (All)
Aliases: rev

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Specifies an URL of a repository. If multiple URLs are given, each will be checked out into a subdirectory of PATH, with the name of the subdirectory being the basename of the URL.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PoshSvn.CmdLets.SvnCheckoutOutput

## NOTES

## RELATED LINKS

[svnadmin-create](https://www.poshsvn.com/docs/Invoke-SvnAdminCreate/)
