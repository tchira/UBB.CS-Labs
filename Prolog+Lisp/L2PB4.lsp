;sa se construiasca lista nodurilor uneui arbore de tip 1 parcurs in inordine
(defun inordine(a)
 (cond
  ((null a) nil)
  (t (append (inordine (car (cdr a))) (cons (car a) (inordine (car (cdr (cdr a))))))) )
)
