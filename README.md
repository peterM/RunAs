![](res/RunAsLogoSmaller.png)


[![Build status](https://dev.azure.com/MalikP/RunAs/_apis/build/status/RunAs)](https://dev.azure.com/MalikP/RunAs/_build/latest?definitionId=7)

This is `runas.exe /netonly .....` replacement to provide support to inject password

### How to run
- Run executable as administrator

### Configuration

#### Configuration file
Open `MalikP.RunAs.exe.config` and update `key` values:
- `UserName`
- `Domain`
- `Password`
- `Command`
- `UseCustomCommandExecutor` [True|False] - _optional_
- `CustomCommandExecutor`
- `CommandArgument`

Or run executable with arguments **(order is mandatory)**:

```powershell
MalikP.RunAs.exe userName domain password "command"
MalikP.RunAs.exe userName domain password "command" UseCustomCommandExecutor CustomCommandExecutor CommandArgument
```

### Execution using command prompt

```powershell
MalikP.RunAs.exe userName domain password "command"
```

### Execution using powershell or other custom executor
```powershell
MalikP.RunAs.exe userName domain password "command" UseCustomCommandExecutor CustomCommandExecutor CommandArgument
```

**Example:**

- _For powershell_
```powershell
MalikP.RunAs.exe userName domain password "command" True "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" "-command"
```

- _For powershell v.6_
```powershell
MalikP.RunAs.exe userName domain password "command" True "C:\Program Files\PowerShell\6\pwsh.exe" "-command"
```

- _For command prompt_
```powershell
MalikP.RunAs.exe userName domain password "command" True "C:\Windows\System32cmd.exe" "/c"
```

### Planned

- enccrypt password saved in configuration file

#### Repository

[https://github.com/peterM/RunAs](https://github.com/peterM/RunAs)