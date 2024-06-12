{ pkgs ? import <nixpkgs> {} }:
pkgs.mkShell {
  nativeBuildInputs = with pkgs; [
                # aot
                nix-ld
              ];

 LD_LIBRARY_PATH = with pkgs; lib.makeLibraryPath ([
   fontconfig
   xorg.libX11
   xorg.libICE
   xorg.libSM
 ]);

}


