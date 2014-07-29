; (defun p (e l)
; "Intoarce pozitia unui element intr-o lista"
; (cond ((null l) 0)
; ((eql e (car l)) 1)
; ((+ 1 (p e (cdr l))))
; )
; )

(defun elimin_aux (n l1 c)
(cond ((null l1) '())
((= n 0) l1)
((= (mod c n) 0) (elimin_aux n (cdr l1) (+ c 1)))
(t (cons (car l1)(elimin_aux n (cdr l1) (+ c 1))))
)
)

(defun elimin (n l)
"Sa se stearga toate elementele din n in n dintr-o lista liniara"
(elimin_aux n l 1)
)