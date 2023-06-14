# dotnet-tcpclient-keepalive-example

This is a example of exchanging keep-alive probes with TcpClient (SO_KEEPALIVE).

## Environments

```sh
$ lsb_release -a
No LSB modules are available.
Distributor ID: Ubuntu
Description:    Ubuntu 22.04.2 LTS
Release:        22.04
Codename:       jammy
```

```sh
$ dotnet --version
7.0.100
```

The sample code in this repository runs on both Windows and Linux; to run it on Windows, uncomment and adjust [client/Program.cs](client/Program.cs).


## Requirements

### Task (go-task)

```sh
$ go install github.com/go-task/task/v3/cmd/task@latest
```

### tcpdump

```sh
$ sudo apt update
$ sudo apt install -y tcpdump
```

## How to Run

Open three terminals. the first terminal, do the following

```sh
$ task capture
```

the second terminal, do the following

```sh
$ task server
```

the third terminal, do the following

```sh
$ task client
```

After a while, the first terminal outputs the following results.

The following is the result of a run on Gitpod.

```sh
$ task capture
task: [capture] sudo tcpdump -i lo 'tcp and port 12345 and tcp[13] & 16 != 0 and tcp[12] & 15 = 0'
tcpdump: verbose output suppressed, use -v[v]... for full protocol decode
listening on lo, link-type EN10MB (Ethernet), snapshot length 262144 bytes
07:16:46.205364 IP localhost.12345 > localhost.51758: Flags [S.], seq 2513543126, ack 2626466582, win 43690, options [mss 65495,sackOK,TS val 4204759295 ecr 4204759295,nop,wscale 7], length 0
07:16:46.205387 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204759295 ecr 4204759295], length 0
07:16:48.210721 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204761300 ecr 4204759295], length 0
07:16:48.210733 IP localhost.12345 > localhost.51758: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204761300 ecr 4204759295], length 0
07:16:50.222709 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204763312 ecr 4204761300], length 0
07:16:50.222716 IP localhost.12345 > localhost.51758: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204763312 ecr 4204759295], length 0
07:16:52.238732 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204765328 ecr 4204763312], length 0
07:16:52.238739 IP localhost.12345 > localhost.51758: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204765328 ecr 4204759295], length 0
07:16:54.254711 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204767344 ecr 4204765328], length 0
07:16:54.254717 IP localhost.12345 > localhost.51758: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204767344 ecr 4204759295], length 0
07:16:56.274647 IP localhost.51758 > localhost.12345: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204769364 ecr 4204767344], length 0
07:16:56.274658 IP localhost.12345 > localhost.51758: Flags [.], ack 1, win 342, options [nop,nop,TS val 4204769364 ecr 4204759295], length 0
07:16:56.410255 IP localhost.51758 > localhost.12345: Flags [F.], seq 1, ack 1, win 342, options [nop,nop,TS val 4204769500 ecr 4204769364], length 0
07:16:56.414705 IP localhost.12345 > localhost.51758: Flags [.], ack 2, win 342, options [nop,nop,TS val 4204769504 ecr 4204769500], length 0
07:16:56.425536 IP localhost.12345 > localhost.51758: Flags [F.], seq 1, ack 2, win 342, options [nop,nop,TS val 4204769515 ecr 4204769500], length 0
07:16:56.425547 IP localhost.51758 > localhost.12345: Flags [.], ack 2, win 342, options [nop,nop,TS val 4204769515 ecr 4204769515], length 0
```
