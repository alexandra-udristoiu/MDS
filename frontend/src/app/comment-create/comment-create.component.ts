import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommentService } from '../_services/comment.service';

@Component({
  selector: 'app-comment-create',
  templateUrl: './comment-create.component.html',
  styleUrls: ['./comment-create.component.css']
})
export class CommentCreateComponent implements OnInit {

  @Input() postId!: number;

  @Output() commentAdd = new EventEmitter();
  
  commentForm!: FormGroup;

  loading: boolean = false;

  submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService
  ) { }

  ngOnInit(): void {
    this.commentForm = this.formBuilder.group({
      text: ['', Validators.required],
    });
  }

  get f() { return this.commentForm.controls; }

  onSubmit() {
    if (this.commentForm.invalid) {
      return;
    }

    const text = this.f['text'].value;
    this.loading = true;
    this.commentService.addComment(this.postId, text)
      .subscribe(
        (data) => {
          this.submitted = true;
          this.commentForm.reset();
          this.commentAdd.emit
        },
        (error) => {
          console.log(error);
          this.loading = false;
        });
  }

}
