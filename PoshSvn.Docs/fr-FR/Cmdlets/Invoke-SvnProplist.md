---
external help file: PoshSvn.dll-Help.xml
Module Name: PoshSvn
online version: https://www.poshsvn.com/docs/Invoke-SvnProplist
schema: 2.0.0
---

# Invoke-SvnProplist

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### Node (Default)
```
Invoke-SvnProplist [[-Target] <SvnTarget[]>] [-Depth <SvnDepth>] [-Recursive] [-Revision <SvnRevision>]
 [-ChangeList <String[]>] [<CommonParameters>]
```

### Revision
```
Invoke-SvnProplist [[-Target] <SvnTarget[]>] [-Depth <SvnDepth>] [-Recursive] [-RevisionProperty]
 -Revision <SvnRevision> [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ChangeList
{{ Fill ChangeList Description }}

```yaml
Type: String[]
Parameter Sets: Node
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
Accepted values: Empty, Files, Immediates, Infinity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Recursive
{{ Fill Recursive Description }}

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

### -Revision
{{ Fill Revision Description }}

```yaml
Type: SvnRevision
Parameter Sets: Node
Aliases: r, rev

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: SvnRevision
Parameter Sets: Revision
Aliases: r, rev

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RevisionProperty
{{ Fill RevisionProperty Description }}

```yaml
Type: SwitchParameter
Parameter Sets: Revision
Aliases: revprop

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
{{ Fill Target Description }}

```yaml
Type: SvnTarget[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PoshSvn.SvnTarget[]
## OUTPUTS

### PoshSvn.SvnProperty
## NOTES

## RELATED LINKS
