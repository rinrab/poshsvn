import * as vscode from 'vscode';

import { findPowerShell } from "./findPowerShell";
import { helpMessage } from "./texts";

export const terminalOptions: vscode.TerminalOptions = {
    name: "PoshSvn terminal",
    shellPath: findPowerShell(),
    message: helpMessage,
    shellArgs: [
        "-NoExit", "-NoLogo",
        "-ExecutionPolicy", "RemoteSigned",
        "-Command", `Import-Module "${__dirname}/PoshSvn/PoshSvn.psd1"`
    ],

    // TODO: fill other parameters
}

export class PoshSvnTerminalProfileProvider implements vscode.TerminalProfileProvider {
    provideTerminalProfile(token: vscode.CancellationToken): vscode.ProviderResult<vscode.TerminalProfile> {
        return {
            options: terminalOptions
        };
    }
}
