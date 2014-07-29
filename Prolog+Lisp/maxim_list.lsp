(defun maxim_list (l)
"Intoarce elementul maxim dintr-o lista"
(cond ((null l) -32000)
((numberp (car l)) (max(car l) (maxim_list (cdr l))))
((atom (car l)) (maxim_list (cdr l)))
)
)

(defun el (l)
(e (maxim_list l) l)
)

(defun e (n l)
"Sterge toate aparitiile elementului maxim"
(cond ((null l) '())
((equal(car l) n) (e n (cdr l)))
(t (cons (car l) (e n (cdr l))))
)
)