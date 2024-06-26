---
external help file: PoshSvn.dll-Help.xml
Module Name: PoshSvn
online version: https://www.poshsvn.com/docs/Invoke-SvnCommit/
schema: 2.0.0
---

# Invoke-SvnCommit

## SYNOPSIS
Send changes from your working copy to the repository.

## SYNTAX

```
Invoke-SvnCommit [[-Path] <String[]>] -Message <String> [-ChangeList <String[]>] [-KeepChangeLists] [-NoUnlock]
 [-Depth <SvnDepth>] [-RevisionProperties <Hashtable>] [<CommonParameters>]
```

## DESCRIPTION
Send changes from your working copy to the repository.

svn-commit will send any lock tokens that it finds and will release locks on all PATHs committed (recursively) unless -NoUnlock is passed.

## EXAMPLES

### Example 1

Commit a simple modification to a file:

```powershell
svn-commit -Message "added howto section."

M        a.txt
Committed revision 3.
```

### Example 2

Commit a file scheduled for deletion:

```powershell
svn-commit -Message "removed file 'c'."

D        c.txt
Committed revision 7.
```

### Example 3

By default, the target of the command refers to your current directory.
Alternatively, you can specify it by setting the `-Path` parameter to a path of your choice:

```powershell
svn-commit -Path C:\path\to\wc -Message "added howto section."

M        a.txt
Committed revision 3.
```

## PARAMETERS

### -ChangeList
{{ Fill ChangeList Description }}

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: cl

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Depth
{{ Fill Depth Description }}

```yaml
Type: SvnDepth
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeepChangeLists
{{ Fill KeepChangeLists Description }}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
Indicates that you will specify either a log message or a lock comment on the command line, following this option. For example: `svn-commit -Message "They don't make Sunday."`

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoUnlock
{{ Fill NoUnlock Description }}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specifies the Path of an item commit. By default is `.` (current directory).

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RevisionProperties
Specifies revision property in new revision.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: with-revprop, rp, revprop

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String[]

## OUTPUTS

### PoshSvn.CmdLets.SvnCommitOutput

## NOTES

## RELATED LINKS
