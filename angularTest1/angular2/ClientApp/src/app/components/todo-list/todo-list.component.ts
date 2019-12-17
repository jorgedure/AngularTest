import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate} from '@angular/animations';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../interfaces/todo';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { NgForOf } from '@angular/common';

@Component({
    selector: 'todo-list',
    templateUrl: './todo-list.component.html',
    styleUrls: ['./todo-list.component.scss'],
    providers: [TodoService],
    animations: [
        trigger('fade', [

            transition(':enter', [
                style({ opacity: 0, transform: 'translateY(30px)' }),
                animate(200, style({ opacity: 1, transform: 'translateY(0px)' }))
            ]),

            transition(':leave', [
                animate(200, style({ opacity: 0, transform: 'translateY(30px)' }))
            ]),

        ])
    ]
})

export class TodoListComponent implements OnInit {
    todoTitle: string;
    todos: Todo[] = [];
    beforeEditCache: string;
    filter: string = 'all';


    constructor(private todoService: TodoService) {

    }

    ngOnInit() {
        this.getTodos();
        this.todoTitle = '';


    }
    addTodo() {
        if (this.todoTitle.trim().length === 0) {
            return;
        }
        this.todoService.addTodo(this.todoTitle).subscribe(result => {
            this.getTodos()
        });
        this.todoTitle = '';
    }

    getTodos() {
        this.todoService.getTodos().subscribe(x => {
            this.todos = x;
            if (this.remaining() == 0) {
                this.todos.forEach(x => !x.check)
            }
        })
    }
    deleteTodo(id: number) {
        this.todoService.deleteTodo(id).subscribe(result => {
            this.getTodos()
        });
    }
    edit(todo) {
        this.todoService.doneEdit(todo).subscribe(result => {
            this.getTodos()
            todo.editing = false;
        });
    }
    doneEdit(todo: Todo) {
        todo.editing = true;
    }
    remaining() {
        return this.todos.filter(todo => !todo.completed).length;
    }
    atLeastOneCompleted() {
        return this.todos.filter(x => x.completed).length > 0;
    }
    clearCompleted() {
        this.todos.filter(y => y.completed).forEach(x => this.deleteTodo(x.id));
    }
    checkAll() {
        if (this.remaining() == 0) {
            this.todos.forEach(x => x.completed = false);
            this.todos.forEach(x => this.edit(x));
        } else {
            this.todos.forEach(x => x.completed = true);
            this.todos.forEach(x => this.edit(x));
        }   
    }
}

