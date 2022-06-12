import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hw } from '../_models/hw';
import { HwService } from '../_services/hw.service';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-homework',
  templateUrl: './homework.component.html',
  styleUrls: ['./homework.component.css']
})
export class HomeworkComponent implements OnInit {

  hw: Hw[] = []

  constructor(
    private router: Router,
    private hwService: HwService,
    public authService: AuthenticationService,
  ) {}

  ngOnInit(): void {
    this.hwService.getHomework().subscribe(
      (hw : Hw[]) => {
        this.hw = hw;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  createPost(): void {
    this.router.navigate(['create-post'])
  }
}
