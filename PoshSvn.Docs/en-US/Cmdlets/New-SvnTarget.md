---
external help file: PoshSvn.dll-Help.xml
Module Name: PoshSvn
online version: https://www.poshsvn.com/docs/New-SvnTarget/
schema: 2.0.0
---

# New-SvnTarget

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### PathOrUrl (Default)
```
New-SvnTarget -InputObject <PSObject> [-Revision <SvnRevision>] [<CommonParameters>]
```

### Path
```
New-SvnTarget [-Path <String>] [-Revision <SvnRevision>] [<CommonParameters>]
```

### LiteralPath
```
New-SvnTarget [-LiteralPath <String>] [-Revision <SvnRevision>] [<CommonParameters>]
```

### Url
```
New-SvnTarget [-Url <String>] [-Revision <SvnRevision>] [<CommonParameters>]
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

### -InputObject
{{ Fill InputObject Description }}

```yaml
Type: PSObject
Parameter Sets: PathOrUrl
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LiteralPath
{{ Fill LiteralPath Description }}

```yaml
Type: String
Parameter Sets: LiteralPath
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
{{ Fill Path Description }}

```yaml
Type: String
Parameter Sets: Path
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
Type: SvnRevision
Parameter Sets: (All)
Aliases: r, rev

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
{{ Fill Url Description }}

```yaml
Type: String
Parameter Sets: Url
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PoshSvn.SvnTarget

## NOTES

## RELATED LINKS
