---
external help file: PoshSvn.dll-Help.xml
Module Name: PoshSvn
online version: https://www.poshsvn.com/docs/Invoke-SvnMergeInfo
schema: 2.0.0
---

# Invoke-SvnMergeInfo

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### __AllParameterSets (Default)
```
Invoke-SvnMergeInfo [-Source] <SvnTarget> [[-Target] <SvnTarget>] [<CommonParameters>]
```

### ShowRevisions
```
Invoke-SvnMergeInfo [-Source] <SvnTarget> [[-Target] <SvnTarget>] [-ShowRevisions <ShowRevisions>] [-Log]
 [-Depth <SvnDepth>] [-Revision <SvnRevisionRange>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Depth
{{ Fill Depth Description }}

```yaml
Type: SvnDepth
Parameter Sets: ShowRevisions
Aliases:
Accepted values: Empty, Files, Immediates, Infinity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Log
{{ Fill Log Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ShowRevisions
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Revision
{{ Fill Revision Description }}

```yaml
Type: SvnRevisionRange
Parameter Sets: ShowRevisions
Aliases: r, rev

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowRevisions
{{ Fill ShowRevisions Description }}

```yaml
Type: ShowRevisions
Parameter Sets: ShowRevisions
Aliases: ShowRevs
Accepted values: Eligible, Merged

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
{{ Fill Source Description }}

```yaml
Type: SvnTarget
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
{{ Fill Target Description }}

```yaml
Type: SvnTarget
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PoshSvn.SvnMergeInfoRevision

## NOTES

## RELATED LINKS