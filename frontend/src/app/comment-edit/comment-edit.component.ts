import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Comment } from '../_models/comment';
import { CommentService } from '../_services/comment.service';

@Component({
  selector: 'app-comment-edit',
  templateUrl: './comment-edit.component.html',
  styleUrls: ['./comment-edit.component.css']
})
export class CommentEditComponent implements OnInit {

  @Input() comment!: Comment;

  @Output() commentEdit = new EventEmitter<any>();

  commentForm!: FormGroup;

  loading: boolean = false;

  submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService
  ) { }

  ngOnInit(): void {
    this.commentForm = this.formBuilder.group({
      text: [this.comment.text, Validators.required],
    });
  }

  get f() { return this.commentForm.controls; }

  onSubmit() {
    if (this.commentForm.invalid) {
      return;
    }

    this.comment.text = this.f['text'].value;
    this.loading = true;
    this.commentService.updateComment(this.comment)
      .subscribe(
        (data) => {
          this.submitted = true;
          this.commentEdit.emit();
        },
        (error) => {
          console.log(error);
          this.loading = false;
    });
  }

}
