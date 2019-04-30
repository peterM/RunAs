# MalikP. RunAs

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

Or run executable with arguments **(order is mandatory)**:

```
MalikP.RunAs.exe userName domain password "command"
```

### Planned

- enccrypt password saved in configuration file

#### Repository

[https://github.com/peterM/RunAs](https://github.com/peterM/RunAs)