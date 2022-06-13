import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hw } from '../_models/hw';
import { AuthenticationService } from '../_services/authentication.service';
import { HwService } from '../_services/hw.service';

@Component({
  selector: 'app-hw-details',
  templateUrl: './hw-details.component.html',
  styleUrls: ['./hw-details.component.css']
})
export class HwDetailsComponent implements OnInit {

  @Input() homework: Hw;
  fileName = '';
  file!: File;

  constructor(
    public hwService: HwService,
    public authService: AuthenticationService,
    private router: Router,
  ) { 
    this.homework = {} as Hw;
  }

  ngOnInit(): void {
    this.fileName = this.homework?.resolveFile?.name || '';
  }

  get isMine(): boolean {
    return this.authService.user.id === this.homework.userId;
  }

  get isDueDate(): boolean {
    return new Date() >= new Date(this.homework.dueDate);
  }

  removeHw(): void {
    this.hwService.removeHw(this.homework.id).subscribe(
      (data) => {
        this.homework = {} as Hw;
      },
      (error: any) => {
        console.log(error);
      });
  }

  onFileSelected(event) {
    const file: File = event.target.files[0];

    if (file) {
        this.fileName = file.name;
        this.file = file;

        this.hwService.resolveHw(this.homework.id, this.authService.user.id, this.file).subscribe(
          (data) => {
            this.homework.resolved = true;
          },
          (error: any) => {
            console.log(error);
          });
    }
  }
}
