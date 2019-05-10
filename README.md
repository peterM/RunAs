![](res/RunAsLogoSmaller.png)


[![Build status](https://dev.azure.com/MalikP/RunAs/_apis/build/status/RunAs)](https://dev.azure.com/MalikP/RunAs/_build/latest?definitionId=7)

This is `runas.exe /netonly .....` replacement to provide support to inject password

### How to run
- Run executable as administrator

### Configuration

#### Configuration file
Open `MalikP.RunAs.exe.config` and update `key` values:
- `CloseHost` [True|False] - _optional_
- `UserName`
- `Domain`
- `Password`
- `Command`

Or run executable with arguments **(order is mandatory)**:

```powershell
MalikP.RunAs.exe userName domain password "command"
MalikP.RunAs.exe userName domain password "command" closeHost
```

### Planned

- enccrypt password saved in configuration file

#### Repository

[https://github.com/peterM/RunAs](https://github.com/peterM/RunAs)